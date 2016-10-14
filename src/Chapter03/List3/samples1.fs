module Strangelights.Sample1
let rec addOneAll list =
    match list with
    | head :: rest -> 
        head + 1 :: addOneAll rest
    | [] -> []
    
printfn "(addOneAll [1; 2; 3]) = %A" (addOneAll [1; 2; 3])