#light
type Base() =
    member x.GetState() = 0
    
type Sub() =
    inherit Base()
    member x.GetOtherState() = 0

let myObject = new Sub()

printfn
    "myObject.state = %i, myObject.otherState = %i"
    (myObject.GetState())
    (myObject.GetOtherState())