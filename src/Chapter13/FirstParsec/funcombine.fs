module Strangelights.Sample4
open FParsec
open FParsec.Primitives

let simpleAdd = CharParsers.pfloat >>= fun x -> 
                CharParsers.spaces >>= fun () -> 
                CharParsers.pfloat >>= fun y -> 
                preturn (x + y)

let pi2 = CharParsers.run simpleAdd "3.1416 3.1416"

printfn "Result: %A" pi2
