#light

// a class with properties
type Properties() =
    let mutable rand = new System.Random()
    // a property definition
    member x.MyProp
        with get () = rand.Next()
        and set y = rand <- new System.Random(y)

// create a new instance of our class
let prop = new Properties()

// run some tests for the class
prop.MyProp <- 12
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp