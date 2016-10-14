module Strangelights.Sample5
open System.IO

// open a file using named arguments
let file = File.Open(path = "test.txt",
                        mode = FileMode.Append,
                        access = FileAccess.Write,
                        share = FileShare.None)

// close it!
file.Close()