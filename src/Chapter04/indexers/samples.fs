#light
open System.Collections.Generic

// create a ResizeArray 
let stringList =
    let temp = new ResizeArray<string>() in
    temp.AddRange([| "one"; "two"; "three" |]);
    temp

// unpack items from the resize array
let itemOne = stringList.Item(0)
let itemTwo = stringList.[1]

// print the unpacked items
printfn "%s %s" itemOne itemTwo