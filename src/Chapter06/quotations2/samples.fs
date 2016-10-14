#light
open Microsoft.FSharp.Quotations

let asciiQuotedInt = <@ 1 @>

printfn "%A" asciiQuotedInt