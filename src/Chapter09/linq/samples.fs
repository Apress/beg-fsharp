module Strangelights.LinqSample
open System
open Strangelights.LinqImports

// query string methods using functions
let namesByFunction =
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic)
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> m.Key, count m)
    |> orderBy (fun (_, m) -> m)

// print out the data we've retrieved from about the string class    
namesByFunction
|> Seq.iter (fun (name, count) -> printfn "%s - %i" name count)