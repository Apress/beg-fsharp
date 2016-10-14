module Strangelights.Sample
open System

let intTextBox x =
    { new obj() 
        interface ICloneable with
            member x.Clone() = new obj() }