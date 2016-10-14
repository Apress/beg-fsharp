open Strangelights.ExpressionParser.Ast
open FParsec
open FParsec.Primitives
open FParsec.OperatorPrecedenceParser

// skips any whitespace
let ws = CharParsers.spaces 

// skips a character possibly postfixed with whitespace
let ch c = CharParsers.skipChar c >>. ws

// parses a floating point number ignoring any postfixed whitespace
let number = CharParsers.pfloat .>> ws |>> (fun x -> Val x)

// parses an identifier made up of letters
let id = 
    CharParsers.many1Satisfy CharParsers.isLetter 
    |>> (fun x -> Ident x)
    .>> ws

// create an new operator precedence parser
let opp = new OperatorPrecedenceParser<_,_>()

// name the expression parser within operator precendce parser
// so it can be used more easily later on
let expr = opp.ExpressionParser

// create a parser to parse everything between the operators
let terms =
    Primitives.choice
        [ id; number; between (ch '(') (ch ')') expr]
opp.TermParser <- terms

// add the operators themselves
opp.AddOperator(InfixOp("+", ws, 1, Assoc.Left, fun x y -> Plus(x, y)))
opp.AddOperator(InfixOp("-", ws, 1, Assoc.Left, fun x y -> Minus(x, y)))
opp.AddOperator(InfixOp("*", ws, 2, Assoc.Left, fun x y -> Multi(x, y)))
opp.AddOperator(InfixOp("/", ws, 2, Assoc.Left, fun x y -> Div(x, y)))

// the complete expression that can be prefixed with whitespace
// and post fixed with an enf of file character
let completeExpression = ws >>. expr .>> CharParsers.eof

// define a function for parsing a string
let parse s = CharParsers.run completeExpression s

// run some tests and print the results
printfn "%A" (parse "1.0 + 2.0 + toto")
printfn "%A" (parse "toto + 1.0 * 2.0")
printfn "%A" (parse "toto + (1.0 + 2.0)")
// will give an error
printfn "%A" (parse "1.0 +")
