let mutableY() =
    let mutable y = "One"
    printfn "Mutating:\r\nx = %s" y
    let f() =
        // this causes an error as
        // mutables can't be captured
        y <- "Two"
        printfn "x = %s" y
    f()
    printfn "x = %s" y