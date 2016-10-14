module Strangelights.Sample2
let lazySideEffect =
    lazy
        ( let temp = 2 + 2
          printfn "%i" temp
          temp )
          
printfn "Force value the first time: "
let actualValue1 = Lazy.force lazySideEffect
printfn "Force value the second time: "
let actualValue2 = Lazy.force lazySideEffect