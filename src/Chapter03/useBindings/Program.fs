﻿open System.IO

// function to read fist line from a file
let readFirstLine filename =
    // open file using a "use" binding
    use file = File.OpenText filename
    file.ReadLine() 

// call function and print the result
printfn "First line was: %s" (readFirstLine "mytext.txt")