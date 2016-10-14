module Strangelights.Sample1
let result =
    if System.DateTime.Now.Second % 2 = 0 then
        "heads"
    else
        "tails"
        
printfn "%A" result