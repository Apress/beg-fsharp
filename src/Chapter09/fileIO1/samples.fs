#light
open System.IO
//test.csv:
//Apples,12,25
//Oranges,12,25
//Bananas,12,25

// open a test file and print the contents
let readFile() =
    let lines = File.ReadAllLines("test.csv")
    let printLine (line: string) =
        let items = line.Split([|','|])
        printfn "%O %O %O"
            items.[0]
            items.[1]
            items.[2]
    Seq.iter printLine lines

do readFile()