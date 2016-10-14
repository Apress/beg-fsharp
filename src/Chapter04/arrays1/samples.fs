#light
// define a jagged array literal
let jagged = [| [| "one" |] ; [| "two" ; "three" |] |]

// unpack elements from the arrays
let singleDim = jagged.[0]
let itemOne = singleDim.[0]
let itemTwo = jagged.[1].[0]

// print some of the unpacked elements
printfn "%s %s" itemOne itemTwo