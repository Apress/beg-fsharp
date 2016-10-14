module Strangelights.Samples2
open System
open System.IO
open System.Threading

let print s =
    let tid = Thread.CurrentThread.ManagedThreadId
    Console.WriteLine(sprintf "Thread %i: %s" tid s)

let readFileSync file =
    print (sprintf "Beginning file %s" file)
    let stream = File.OpenText(file)
    let fileContents = stream.ReadToEnd()
    print (sprintf "Ending file %s" file)
    fileContents


// invoke the workflow and get the contents
let filesContents = 
    [| readFileSync "text1.txt";
       readFileSync "text2.txt"; 
       readFileSync "text3.txt"; |]