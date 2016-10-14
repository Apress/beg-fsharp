#light
open System.IO

let recopy path i =
    let folder = Path.GetDirectoryName path 
    let name = Path.GetFileNameWithoutExtension path
    let ext = Path.GetExtension path
    for x in 1 .. i do
        File.Copy(path, (sprintf "%s\\%s%i%s" folder name x ext))


recopy @"C:\gutenberg\bibles\Bible-Douay-Rheims.txt" 50
