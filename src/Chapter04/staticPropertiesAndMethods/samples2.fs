module Strangelights.Sample2
open System.IO

// list of files to test
let files1 = [ "test1.txt"; "test2.txt"; "test3.txt" ]

// test if each file exists
let results1 =  List.map File.Exists files1

// print the results
printfn "%A" results1