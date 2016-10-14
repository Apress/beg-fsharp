#light
// a record with a mutable field
type Couple = { Her: string; mutable Him: string }

// a create an instance of the record
let theCouple = { Her = "Elizabeth Taylor "; Him = "Nicky Hilton" }

// function to change the contents of 
// the record over time
let changeCouple() =
    printfn "%A" theCouple
    theCouple.Him <- "Michael Wilding"
    printfn "%A" theCouple
    theCouple.Him <- "Michael Todd"
    printfn "%A" theCouple
    theCouple.Him <- "Eddie Fisher"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "John Warner"
    printfn "%A" theCouple
    theCouple.Him <- "Larry Fortensky"
    printfn "%A" theCouple

// call the fucntion
changeCouple()
