module Strangelights.Sample2

let totalArray () =
    // define an array literal
    let array = [| 1; 2; 3 |]
    // define a counter
    let total = ref 0
    // loop over the array
    for x in array do
        // kep a running total
        total := !total + x
    // print the total
    printfn "total: %i" !total
    
totalArray()