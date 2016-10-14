module Strangelights.Sample1
open FParsec

let pi = CharParsers.run CharParsers.pfloat "3.1416"

printfn "Result: %A" pi
