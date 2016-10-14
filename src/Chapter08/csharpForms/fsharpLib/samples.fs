#light
module Strangelights.Fibonacci

// an infinite sequence of Fibonacci numbers
let fibs =
    (1,1) |> Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))
            
// a function to get the nth fibonacci number
let get n =
    Seq.nth n fibs