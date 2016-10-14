open Microsoft.FSharp.Reflection
let printTupleValues (x: obj) =
    if FSharpType.IsTuple(x.GetType()) then
        let vals = FSharpValue.GetTupleFields x
        printf "("
        vals
        |> Seq.iteri
            (fun i v ->
                if i <> Seq.length vals - 1 then
                    printf " %A, " v
                else
                    printf " %A" v)
        printfn " )"
    else
        printfn "not a tuple"
    
printTupleValues ("hello world", 1)