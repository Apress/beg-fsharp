module Strangelights.Sample1
open System.IO
// test whether a file "test.txt" exist
if File.Exists("test.txt") then
    printfn "Text file \"test.txt\" is present"
else
    printfn "Text file \"test.txt\" does not exist"