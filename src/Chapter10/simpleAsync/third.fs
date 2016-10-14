module Strangelights.Samples3
open System
open System.IO
open System.Threading

let print s =
    let tid = Thread.CurrentThread.ManagedThreadId
    Console.WriteLine(sprintf "Thread %i: %s" tid s)

// a function to read a text file asynchronusly
let readFileAsync file =
    async { do print (sprintf "Beginning file %s" file)
            let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            do print (sprintf "Ending file %s" file)
            return fileContents }

let filesContents = 
    Async.RunSynchronously
        (Async.Parallel [ readFileAsync "text1.txt";
                          readFileAsync "text2.txt"; 
                          readFileAsync "text3.txt"; ])