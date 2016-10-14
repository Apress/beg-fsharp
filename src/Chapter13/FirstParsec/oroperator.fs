module Strangelights.Sample6
open FParsec
open FParsec.Primitives

type AstFragment =
    | Val of float
    | Ident of string

let number = CharParsers.pfloat |>> (fun x -> Val x)

let id = 
    CharParsers.many1Satisfy CharParsers.isLetter 
    |>> (fun x -> Ident x)

let stringOrFloat = id <|> number

let num = CharParsers.run stringOrFloat "3.1416"
let ident = CharParsers.run stringOrFloat "anIdent"


printfn "Result 'num': %A Result 'ident': %A" num ident
