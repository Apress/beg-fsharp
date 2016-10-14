let tenOnes = Seq.init 10 (fun _ -> 1)
let allIntegers = Seq.initInfinite (fun x -> System.Int32.MinValue + x)
let firstTenInts = Seq.take 10 allIntegers

tenOnes |> Seq.iter (fun x -> printf "%i ... " x)
printfn ""
printfn "%A" firstTenInts