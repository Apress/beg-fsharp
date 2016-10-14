#light
module ModuleOne
// statements at the top-level
printfn "This is the first line"
printfn "This is the second"

// a value defined at the top-level
let file =
    let temp = new System.IO.FileInfo("test.txt") in
    printfn "File exists: %b" temp.Exists
    temp