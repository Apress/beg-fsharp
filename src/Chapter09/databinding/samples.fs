#light
open System
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open System.Windows.Forms

// creates a connections then executes the given command on it
let opener commandString =
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

// read each row from the data reader into a dictionary    
let generator (reader: IDataReader) =
    if reader.Read() then
        let dict = new Dictionary<string, obj>()
        for x in [ 0 .. (reader.FieldCount - 1) ] do
            dict.Add(reader.GetName(x), reader.Item(x))
        Some(dict)
    else
        None

// executes a database command returning a sequence containing the results
let execCommand commandString =
    Seq.generate
        (fun () -> opener commandString)
        (fun r -> generator r)
        (fun r -> r.Dispose())

// get the contents of the contacts table     
let contactsTable =
    execCommand
        "select top 10 * from Person.Contact"

// create a list of first and last names
let contacts =
    [| for row in contactsTable ->
        Printf.sprintf "%O %O"
            (row.["FirstName"])
            (row.["LastName"]) |]

// create form containing a ComboBox with results list
let form =
    let temp = new Form()
    let combo = new ComboBox(Top=8, Left=8, DataSource=contacts)
    temp.Controls.Add(combo)
    temp

// show the form    
Application.Run(form)
