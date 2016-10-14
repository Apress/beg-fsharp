#light
module ModuleTwo
// these two lines should be printed first
printfn "This is the first line"
printfn "This is the second"

// function to access ModuleOne
let funct() =
    printfn "%i" ModuleOne.n
    
funct()
