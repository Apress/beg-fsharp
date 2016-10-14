#light
open Microsoft.FSharp.Quotations

// quote an operator applied to two operands
let quotedOp = <@ 1 + 1 @>

// print the quotation
printfn "%A" quotedOp