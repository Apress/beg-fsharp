#light
open System.Configuration

// read an application setting
let setting = ConfigurationManager.AppSettings.["MySetting"]

// print the setting
printfn "%s" setting