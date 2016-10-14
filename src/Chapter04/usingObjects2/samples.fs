#light
open System
// how to wrap a method that take a delegate with an F# function
let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))

// define an array literal
let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat" |]

// print index of the first word ending in 'at'
printfn "First word ending in 'at' in the array: %i"
    (rhyme |> findIndex (fun w -> w.EndsWith("at")))
