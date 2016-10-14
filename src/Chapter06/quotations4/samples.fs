#light
open Microsoft.FSharp.Quotations

// define a function
let inc x = x + 1
// quote the function applied to a value
let quotedFun = <@ inc 1 @>

// print the quotation
printfn "%A" quotedFun