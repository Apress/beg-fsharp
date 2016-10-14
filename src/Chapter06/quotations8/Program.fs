open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

// a function to interpret very simple quotations
let rec interpret exp =
    match exp with
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int)
    | SpecificCall <@ (+) @> (_, _, [l;r])  -> interpret l 
                                               printfn "+"
                                               interpret r
    | _ -> printfn "not supported"
        
// test the function
interpret <@ 1 @>
interpret <@ 1 + 1 @>        
