module Strangelights.Samples1
open System.IO

// a function to read a text file asynchronusly
let readFile file =
    async { let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            return fileContents }

// create an instance of the workflow
let readFileWorkflow = readFile "mytextfile.txt"

// invoke the workflow and get the contents
let fileContents = Async.RunSynchronously readFileWorkflow