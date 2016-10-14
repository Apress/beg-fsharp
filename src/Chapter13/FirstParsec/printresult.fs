module Strangelights.Sample2
open FParsec

let parseAndPrint input =
    let result = CharParsers.run CharParsers.pfloat input
    match result with
    | CharParsers.Success (result, _, _) -> 
        printfn "result: %A" result
    | CharParsers.Failure (_, errorDetails, _) -> 
        printfn "Error details: %A" errorDetails

parseAndPrint "3.1416"
parseAndPrint "    3.1416"
parseAndPrint "Not a number"
