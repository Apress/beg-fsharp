module Strangelights.Sample2
let rec map func list =
    match list with
    | head :: rest -> 
        func head :: map func rest
    | [] -> []