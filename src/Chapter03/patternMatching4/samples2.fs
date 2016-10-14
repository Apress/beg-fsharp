module Strangelights.Sample2
// concatenate a list of strings into single string
let rec conactStringList =
    function head :: tail -> head + conactStringList tail
           | [] -> ""

// test data
let jabber = ["'Twas "; "brillig, "; "and "; "the "; "slithy "; "toves "; "..."]
// call the function
let completJabber = conactStringList jabber
// print the result
printfn "%s" completJabber