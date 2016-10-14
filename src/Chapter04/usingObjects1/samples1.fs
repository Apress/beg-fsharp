module Strangelights.Sample1
open System.IO
// file name to test
let filename = "test.txt"

// bind file to an option type, depending on whether
// the file exist or not
let file =
    if File.Exists(filename) then
        Some(new FileInfo(filename, Attributes = FileAttributes.ReadOnly))
    else
        None