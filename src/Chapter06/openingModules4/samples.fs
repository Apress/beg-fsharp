#light
// module of operators
module MyOps =
    // check equality via hash code
    let (===) x y = 
        x.GetHashCode() = 
          y.GetHashCode()

// open the MyOps module
open MyOps

// use the triple equal operator
let equal = 1 === 1
let nEqual = 1 === 2