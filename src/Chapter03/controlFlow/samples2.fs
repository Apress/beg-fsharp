module Strangelights.Sample2
let result =
    if System.DateTime.Now.Second % 2 = 0 then
        box "heads"
    else
        box false
        
printfn "%A" result