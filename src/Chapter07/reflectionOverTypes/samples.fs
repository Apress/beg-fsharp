open Microsoft.FSharp.Reflection

let printTupleTypes (x: obj) =
    let t = x.GetType()
    if FSharpType.IsTuple t then
        let types = FSharpType.GetTupleElements t
        printf "("
        types
        |> Seq.iteri
            (fun i t ->
            if i <> Seq.length types - 1 then
                printf " %s * " t.Name
            else
                printf "%s" t.Name)
        printfn " )"
    else 
        printfn "not a tuple"
    
printTupleTypes ("hello world", 1)