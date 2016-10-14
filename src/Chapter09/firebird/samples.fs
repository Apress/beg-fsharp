#light
open System.Configuration
open System.Collections.Generic
open System.Data
open FirebirdSql.Data.FirebirdClient
open System.Data.Common
open System

// firebird connection string
let connectionString =
    @"Database=C:\Program Files\Firebird\" +
    @"Firebird_2_0\examples\empbuild\EMPLOYEE.FDB;" +
    @"User=SYSDBA;" + "Password=masterkey;" +
    @"Dialect=3;" + "Server=localhost";
    
// open firebird connection
let openFBConnection() =
    let connection = new FbConnection (connectionString)
    connection.Open();
    connection

// create a reader to read all the information
let openConnectionReader cmdString =
    let conn = openFBConnection()
    let cmd = conn.CreateCommand(CommandText = cmdString,
                                 CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader

// read a row from the database and convert into a dictionary
let readOneRow (reader: #DbDataReader) =
    if reader.Read() then
        let dict = new Dictionary<string, obj>()
        for x = 0 to (reader.FieldCount - 1) do
            dict.Add(reader.GetName(x), reader.Item(x))
        Some(dict)
    else
        None

// execute a database command creating a sequence of the results
let execCommand cmdString =
    Seq.generate
        // This function gets called to open a conn and create a reader
        (fun () -> openConnectionReader cmdString)
        // This function gets called to read a single item in
        // the enumerable for a reader/conn pair
        (fun reader -> readOneRow(reader))
        (fun reader -> reader.Dispose())

// select all from the Employee's table        
let employeeTable =
    execCommand
        "select * from Employee"

// print out the Employee's information
for row in employeeTable do
    for col in row.Keys do
        printfn "%s = %O " col (row.Item(col))
