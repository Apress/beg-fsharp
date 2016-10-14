#light

// A point type
type Point =
    { Top: int;
      Left: int }
    with
        // the swap member creates a new point
        // with the left/top coords reveresed
        member x.Swap() =
            { Top = x.Left;
              Left = x.Top }

// create a new point
let myPoint = 
    { Top = 3;
      Left = 7 }
     
let main() =
    // print the inital point
    printfn "%A" myPoint
    // create a new point with the coords swapped
    let nextPoint = myPoint.Swap()
    // print the new point
    printfn "%A" nextPoint

// start the app
do main()