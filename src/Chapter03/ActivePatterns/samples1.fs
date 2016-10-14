﻿module Strangelights.Sample1
open System

// definition of the active pattern
let (|Bool|Int|Float|String|) input =
    // attempt to parse a bool
    let sucess, res = Boolean.TryParse input
    if sucess then Bool(res)
    else 
        // attempt to parse an int
        let sucess, res = Int32.TryParse input
        if sucess then Int(res)
        else
            // attempt to parse a float (Double)
            let sucess, res = Double.TryParse input
            if sucess then Float(res)
            else String(input)

// function to print the results by pattern
// matching over the active pattern
let printInputWithType input =
    match input with
    | Bool b -> printfn "Boolean: %b" b
    | Int i -> printfn "Integer: %i" i
    | Float f -> printfn "Floating point: %f" f
    | String s -> printfn "String: %s" s

// print the results    
printInputWithType "true"
printInputWithType "12"
printInputWithType "-12.1"
