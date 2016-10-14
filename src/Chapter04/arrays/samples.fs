#light

// define an array literal
let rhymeArray =
    [| "Went to market";
       "Stayed home";
       "Had roast beef";
       "Had none" |]

// unpack the array into identifiers
let firstPiggy = rhymeArray.[0]
let secondPiggy = rhymeArray.[1]
let thirdPiggy = rhymeArray.[2]
let fourthPiggy = rhymeArray.[3]

// update elements of the array
rhymeArray.[0] <- "Wee,"
rhymeArray.[1] <- "wee,"
rhymeArray.[2] <- "wee,"
rhymeArray.[3] <- "all the way home"

// give a short name to the new line characters
let nl = System.Environment.NewLine

// print out the identifiers & array
printfn "%s%s%s%s%s%s%s" 
    firstPiggy nl 
    secondPiggy nl 
    thirdPiggy nl 
    fourthPiggy
printfn "%A" rhymeArray