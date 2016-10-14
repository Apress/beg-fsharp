module Strangelights.Sample1
open System.Threading

Parallel.For(0, 100, (printfn "%i"))