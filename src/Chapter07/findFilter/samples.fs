let shortWordList = [|"hat"; "hot"; "bat"; "lot"; "mat"; "dot"; "rat";|]

let atWords =
    shortWordList
    |> Seq.filter (fun x -> x.EndsWith("at"))
    
let otWord =
    shortWordList
    |> Seq.find (fun x -> x.EndsWith("ot"))
    
let ttWord =
    shortWordList
    |> Seq.tryFind (fun x -> x.EndsWith("tt"))
    
atWords |> Seq.iter (fun x -> printf "%s ... " x)
printfn ""
printfn "%s" otWord
printfn "%s" (match ttWord with | Some x -> x | None -> "Not found")