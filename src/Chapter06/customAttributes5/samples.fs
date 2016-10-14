open System

// create a list of all obsolete types
let obsolete = AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray
                |> List.map (fun assm -> assm.GetTypes())
                |> Array.concat
                |> List.ofArray
                |> List.filter (fun m ->
                    m.IsDefined(typeof<ObsoleteAttribute>, true))

// print the lists
printfn "%A" obsolete