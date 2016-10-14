#light
open System.Configuration

// get the connection string
let connectionStringDetails =
    ConfigurationManager.ConnectionStrings.["MyConnectionString"]

// print the details
printfn "%s\r\n%s"
    connectionStringDetails.ConnectionString
    connectionStringDetails.ProviderName