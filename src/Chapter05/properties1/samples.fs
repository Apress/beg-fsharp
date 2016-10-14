module Strangelights.Sample
// an interface with an abstract property
type IAbstractProperties =
    abstract MyProp: int
        with get, set

// a class that implements our interface
type ConcreteProperties() =
    let mutable rand = new System.Random()
    interface IAbstractProperties with
        member x.MyProp
            with get() = rand.Next()
            and set(y) = rand <- new System.Random(y)
