#light

// demonstration of redefining X
let redefineX() =
    let x = "One"
    printfn "Redefining:\r\nx = %s" x
    if true then
        let x = "Two"
        printfn "x = %s" x
    else ()
    printfn "x = %s" x
    
// demonstration of mutating X
let mutableX() =
    let mutable x = "One"
    printfn "Mutating:\r\nx = %s" x
    if true then
        x <- "Two"
        printfn "x = %s" x
    else ()
    printfn "x = %s" x

// run the demos
redefineX()
mutableX()