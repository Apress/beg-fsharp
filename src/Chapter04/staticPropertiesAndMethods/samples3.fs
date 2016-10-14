module Strangelights.Sample3
open System.IO

// list of files names and desired contents
let files2 = [ "test1.bin", [| 0uy |]; 
               "test2.bin", [| 1uy |]; 
               "test3.bin", [| 1uy; 2uy |]]

// iterator over the list of files creating each one
List.iter File.WriteAllBytes files2