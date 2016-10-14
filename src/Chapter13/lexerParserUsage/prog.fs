module Strangelights.ExpressionParser.Main
open System.Text
open Microsoft.FSharp.Text.Lexing
open Strangelights.ExpressionParser
let lexbuf = LexBuffer<byte>.FromBytes(Encoding.ASCII.GetBytes("1"))
let token = Lexer.token lexbuf
printfn "%A" token

open System.Text
open Microsoft.FSharp.Text.Lexing
let lexbuf2 = 
    LexBuffer<byte>.FromBytes(Encoding.ASCII.GetBytes("(1 * 1) + 2"))
while not lexbuf2.IsPastEndOfStream do
    let token = Lexer.token lexbuf2
    printfn "%A" token

open System.IO
open Microsoft.FSharp.Text.Lexing
let lexbuf3 = 
    LexBuffer<byte>.FromBytes(Encoding.ASCII.GetBytes("(1 * 1) + 2"))
let e = Parser.Expression Lexer.token lexbuf3
printfn "%A" token
