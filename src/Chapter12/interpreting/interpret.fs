#light
open System
open System.Collections.Generic
open Strangelights.Expression

// requesting a value for variable from the user
let getVariableValues e =
    let rec getVariableValuesInner input (variables : Map<string, float>) =
        match input with
        | Ident (s) ->
            match variables.TryFind(s) with
            | Some _ -> variables
            | None ->
                printf "%s: " s
                let v = float(Console.ReadLine())
                variables.Add(s,v)
        | Multi (e1, e2) -> 
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Div (e1, e2) -> 
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Plus (e1, e2) ->
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Minus (e1, e2) ->
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | _ -> variables
    getVariableValuesInner e (Map.empty)

// function to handle the interpretation
let interpret input (variableDict : Map<string,float>) = 
    let rec interpretInner input =
        match input with
        | Ident (s) -> variableDict.[s] 
        | Val (v) -> v
        | Multi (e1, e2) -> (interpretInner e1) * (interpretInner e2)
        | Div (e1, e2) -> (interpretInner e1) / (interpretInner e2)
        | Plus (e1, e2) -> (interpretInner e1) + (interpretInner e2)
        | Minus (e1, e2) -> (interpretInner e1) - (interpretInner e2)
    interpretInner input
    
// the expression to be interpreted
let e = Multi(Val 2., Plus(Val 2., Ident "a"))

// collect the arguments from the user
let args = getVariableValues e

// interpret the expression
let v = interpret e args

// print the results
printf "result: %f" v
