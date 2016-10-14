#light
open Microsoft.FSharp.Quotations.Patterns

// a function to interpret very simple quotations
let interpretInt exp =
    match exp with
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int)
    | _ -> printfn "not an int"
        
// test the function
interpretInt <@ 1 @>
interpretInt <@ 1 + 1 @>