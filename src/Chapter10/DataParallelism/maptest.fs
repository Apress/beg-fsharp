open System.Diagnostics
open Strangelights.Extensions

// the number of samples to collect
let samples = 5
// the number of times to repeat each test within a sample
let runs = 100

// this function provides the "work", by enumerating over a 
// collection of a given size
let addSlowly x =
    Seq.fold (fun acc _ -> acc + 1) 0 (seq { 1 .. x })

// tests the sequentual map function by performing a map on a 
// a list with the given number of items and performing the given
// number of opertions for each item.
// the map is then iterated, to force it to perform the work.
let testMap mapVersion items ops =
    mapVersion (fun _ -> addSlowly ops) (seq { 1 .. items })
    |> Seq.iter (fun _ -> ())

// a test harness function, takes a function and passes it the give
let harness mapVersion items ops =
    // run once to ensure everything is JITed
    testMap mapVersion items ops
    // collect a list of results
    let res =
        [ for _ in 1 .. samples do
                let clock = new Stopwatch()
                clock.Start()
                for _ in 1 .. runs do 
                    testMap mapVersion items ops
                clock.Stop()
                yield clock.ElapsedMilliseconds ]
    // calculate the average
    let avg = float (Seq.reduce (+) res) / (float samples)
    // output the results
    printf "Items %i, Ops %i," items ops
    Seq.iter (printf "%i,") res
    printfn "%f" avg

// the parameters to use
let itemsList = [ 10; 100; 200; 400; 800; 1000 ]
let opsList = [ 1; 10; 100; 200; 400; 800; 1000 ]

// function that runs the test harness variy the input parameters
let runTests mapVersion =
    for items in itemsList do
        for ops in opsList do
            harness mapVersion items ops

// test the sequential function
runTests Seq.map

// test the parallel function
runTests PSeq.map