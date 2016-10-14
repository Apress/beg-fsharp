let printMessages() =
    // define message and print it
    let message = "Important"
    printfn "%s" message;
    // define an inner function that redefines value of message
    let innerFun () =
        let message = "Very Important"
        printfn "%s" message
    // call the inner function
    innerFun ()
    // finally print the first message again
    printfn "%s" message
    
printMessages()