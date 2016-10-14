#light
open System.IO

// list all the files in the root of C: drive
let files = Directory.GetFiles(@"c:\")

// write out various information about the file
for filepath in files do
    let file = new FileInfo(filepath)
    printfn "%s\t%d\t%O"
        file.Name
        file.Length
        file.CreationTime
