#light
// a base class
type Base() =
    // some internal state for the class
    let mutable state = 0
    // an ordinary member method
    member x.JiggleState y = state <- y
    // an abstract method
    abstract WiggleState: int -> unit
    // a default implementation for the abstract method
    default x.WiggleState y = state <- y + state
    member x.GetState() = state

// a sub class
type Sub() =
    inherit Base()
    // override the abstract method
    default x.WiggleState y = x.JiggleState (x.GetState() &&& y)

// create instances of both methods
let myBase = new Base()
let mySub = new Sub()

// a small test for our classes
let testBehavior (c : #Base) =
    c.JiggleState 1
    printfn "%i" (c.GetState())
    c.WiggleState 3
    printfn "%i" (c.GetState())

// run the tests
let main() =    
    printfn "base class: "
    testBehavior myBase
    printfn "sub class: "
    testBehavior mySub

do main()