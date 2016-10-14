// grab a list of all methods in memory
let methods = System.AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray 
                |> List.map ( fun assm -> assm.GetTypes() ) 
                |> Array.concat
                |> List.ofArray 
                |> List.map ( fun t -> t.GetMethods() ) 
                |> Array.concat

// print the list
printfn "%A" methods