#light
open Microsoft.FSharp.Quotations

// quote an anonymous function
let quotedAnonFun = <@ fun x -> x + 1 @>

// print the quotation
printfn "%A" quotedAnonFun