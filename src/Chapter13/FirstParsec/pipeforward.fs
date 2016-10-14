module Strangelights.Sample5
open FParsec
open FParsec.Primitives

let addTwo = CharParsers.pfloat |>> (fun x -> x + 2.0)

let pi2 = CharParsers.run addTwo "3.1416"

printfn "Result: %A" pi2
