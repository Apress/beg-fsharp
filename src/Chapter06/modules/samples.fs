#light
// create a top level module
module ModuleDemo

// create a first module
module FirstModule =
    let n = 1
    
// create a second module
module SecondModule =
    let n = 2
    // create a third module 
    // nested inside the second
    module ThirdModule =
        let n = 3