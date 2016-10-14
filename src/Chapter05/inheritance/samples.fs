#light
// define a base class
type Base(state) = class
    member x.GetState() = state
end

// define a class that inherits from Base
type Sub(state) = class
    inherit Base(state)
    member x.GetOtherState() = state
end

// create a new instance of the sub class
let myObject = new Sub(1)

// test the object
let main() =
    printfn "myObject.State = %i, myObject.OtherState = %i"
            (myObject.GetState())
            (myObject.GetOtherState())

do main()