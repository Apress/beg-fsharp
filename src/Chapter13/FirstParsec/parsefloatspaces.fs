module Strangelights.Sample3
open FParsec
open FParsec.Primitives

let wsfloat = CharParsers.spaces >>. CharParsers.pfloat

let pi = CharParsers.run wsfloat "    3.1416"

printfn "Result: %A" pi