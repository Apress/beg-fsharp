open System.IO
// create a FileInfo object
let file = new FileInfo("test.txt")

// test if the file exists,
// if not create a file
if not file.Exists then
    use stream = file.CreateText()
    stream.WriteLine("hello world")
    file.Attributes <- FileAttributes.ReadOnly

// print the full file name
printfn "%s" file.FullName