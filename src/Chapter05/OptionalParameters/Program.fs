type AClass(?someState:int) =
    let state =
        match someState with
        | Some x -> string x
        | None -> "<no input>"
    member x.PrintState (prefix, ?postfix) =
        match postfix with
        | Some x -> printfn "%s %s %s" prefix state x
        | None -> printfn "%s %s" prefix state

let aClass = new AClass()
let aClass' = new AClass(109)

aClass.PrintState("There was ")
aClass'.PrintState("Input was:", ", which is nice.")