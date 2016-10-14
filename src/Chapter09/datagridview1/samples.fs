#light
module Strangelights.DataTools
open System
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open Microsoft.FSharp.Reflection

// a command that returns dynamically created stongly typed collection
let execCommand<'a> commandString : seq<'a> =
    // the opener that executes the command
    let opener() =
        // read the connection string
        let connectionSetting =
            ConfigurationManager.ConnectionStrings.["MyConnection"]
        
        // create the connection and open it
        let conn = new SqlConnection(connectionSetting.ConnectionString)
        conn.Open()
        
        // excute the command, ensuring the read will close the connection
        let cmd = conn.CreateCommand(CommandType = CommandType.Text, 
                                     CommandText = commandString)
        cmd.ExecuteReader(CommandBehavior.CloseConnection)
    
    // the generator, that generates an strongly typed object for each row
    let generator (reader : IDataReader) =
        if reader.Read() then
            // get the type object and its properties
            let t = typeof<'a>
            
            // get the values for the row from the reader
            let values = Array.create reader.FieldCount (new obj())
            reader.GetValues(values) |> ignore
            let convertVals x = match box x with | :? DBNull -> null | _ -> x
            let values = Array.map convertVals values
            
            // create the record and return it
            Some (FSharpValue.MakeRecord(t, values) :?> 'a)
        else
            None

    // generate the sequence            
    Seq.generate
        opener
        generator
        (fun r -> r.Dispose())