#light

// this defines a function and quotes it
[<ReflectedDefinition>]
let inc n = n + 1

// fetch the quoted defintion
let incQuote = <@@ inc @@>

// print the quotation
printfn "%A" incQuote
// use the function
printfn "inc 1: %i" (inc 1)