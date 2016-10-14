#light

// capute the inc, dec and show funtions
let inc, dec, show =
    // define the shared state
    let n = ref 0
    // a function to increment
    let inc () =
        n := !n + 1
    // a function to decrement
    let dec () =
        n := !n - 1
    // a function to show the current state
    let show () =
        printfn "%i" !n
    
    // return the functions to the top level
    inc, dec, show
    
// test the functions
inc()
inc()
dec()
show()