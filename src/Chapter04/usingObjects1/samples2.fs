module Strangelights.Sample2
open System

// an integer list
let intList =
    let temp = new ResizeArray<int>() in
    temp.AddRange([| 1; 2; 3 |]);
    temp

// print each int using the ForEach member method
intList.ForEach( fun i -> Console.WriteLine(i) )