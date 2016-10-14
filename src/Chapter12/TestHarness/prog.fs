open System
open System.Diagnostics
open Strangelights.Expression

// expression to process
let e = Multi(Val 2., Plus(Val 2., Val 2.))

// collect the inputs
printf "Interpret/Compile/Compile Through Delegate [i/c/cd]: "
let interpertFlag = Console.ReadLine()
printf "reps: "
let reps = int(Console.ReadLine())

type Df0 = delegate of unit -> float
type Df1 = delegate of float -> float
type Df2 = delegate of float * float -> float
type Df3 = delegate of float * float * float -> float
type Df4 = delegate of float * float * float * float -> float

// run the tests
match interpertFlag with
| "i" ->
    let args = Interpret.getVariableValues e
    let clock = new Stopwatch()
    clock.Start()
    for i = 1 to reps do
        Interpret.interpret e args |> ignore
    clock.Stop()
    printf "%i" clock.ElapsedTicks
| "c" ->
    let paramNames = Compile.getParamList e
    let dm = Compile.createDynamicMethod e paramNames
    let args = Compile.collectArgs paramNames
    let clock = new Stopwatch()
    clock.Start()
    for i = 1 to reps do
        dm.Invoke(null, args) |> ignore
    clock.Stop()
    printf "%i" clock.ElapsedTicks
| "cd" ->
    let paramNames = Compile.getParamList e
    let dm = Compile.createDynamicMethod e paramNames
    let args = Compile.collectArgs paramNames
    let args = args |> Array.map (fun f -> f :?> float)
    let d =
        match args.Length with
        | 0 -> dm.CreateDelegate(typeof<Df0>)
        | 1 -> dm.CreateDelegate(typeof<Df1>)
        | 2 -> dm.CreateDelegate(typeof<Df2>)
        | 3 -> dm.CreateDelegate(typeof<Df3>)
        | 4 -> dm.CreateDelegate(typeof<Df4>)
        | _ -> failwith "too many parameters"
    let clock = new Stopwatch()
    clock.Start()
    for i = 1 to reps do
        match d with
        | :? Df0 as d -> d.Invoke() |> ignore
        | :? Df1 as d -> d.Invoke(args.[0]) |> ignore
        | :? Df2 as d -> d.Invoke(args.[0], args.[1]) |> ignore
        | :? Df3 as d -> d.Invoke(args.[0], args.[1], args.[2]) |> ignore
        | :? Df4 as d -> d.Invoke(args.[0], args.[1], args.[2], args.[4]) |> ignore
        | _ -> failwith "too many parameters"
    clock.Stop()
    printf "%i" clock.ElapsedTicks
| _ -> failwith "not an option"        

