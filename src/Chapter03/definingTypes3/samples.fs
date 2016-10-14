module Strangelights.Sample1
// type representing a couple
type Couple = { him : string ; her : string }

// list of couples
let couples =
    [ { him = "Brad" ; her = "Angelina" };
      { him = "Becks" ; her = "Posh" };
      { him = "Chris" ; her = "Gwyneth" };
      { him = "Michael" ; her = "Catherine" } ]
    
// function to find "David" from a list of couples
let rec findDavid l =
    match l with
    | { him = x ; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"

// print the results    
printfn "%A" (findDavid couples)