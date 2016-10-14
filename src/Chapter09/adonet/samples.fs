#light
open System.Configuration
open System.Data
open System.Data.SqlClient

// get the connection string    
let connectionString =
    let connectionSetting =
        ConfigurationManager.ConnectionStrings.["MyConnection"]
    connectionSetting.ConnectionString

let main() =
    // create a connection
    use connection = new SqlConnection(connectionString)
    
    // create a command
    let command =
        connection.CreateCommand(CommandText = "select * from Person.Contact",
                                 CommandType = CommandType.Text)

    // open the connection
    connection.Open()

    // open a reader to read data from the DB
    use reader = command.ExecuteReader()

    // fetch the ordinals
    let title = reader.GetOrdinal("Title")
    let firstName = reader.GetOrdinal("FirstName")
    let lastName = reader.GetOrdinal("LastName")
    
    // function to read strings from the data reader
    let getString (r: #IDataReader) x =
        if r.IsDBNull(x) then ""
        else r.GetString(x)
    
    // read all the items
    while reader.Read() do
        printfn "%s %s %s"
            (getString reader title )
            (getString reader firstName)
            (getString reader lastName)

main()