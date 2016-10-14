namespace Strangelights.Expression

type Ast = 
  | Ident of string 
  | Val of System.Double
  | Multi of Ast * Ast
  | Div of Ast * Ast
  | Plus of Ast * Ast
  | Minus of Ast * Ast
