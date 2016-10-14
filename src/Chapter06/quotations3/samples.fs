#light
open Microsoft.FSharp.Quotations

// define an identifier n
let n = 1
// quote the identifier
let quotedId = <@ n @>

// print the quoted identifier
printfn "%A" quotedId