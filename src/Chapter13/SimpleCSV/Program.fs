open System.IO

let parseFile filename =
    let lines = File.ReadAllLines filename
    seq { for line in lines -> line.Split(',') }