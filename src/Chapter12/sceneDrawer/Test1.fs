module Strangelights.Sample1
open System.Drawing
open System.Windows.Forms
open Strangelights.GraphicDSL

// two test squares
let square1 = Combinators.square true (100, 50) 50 
let square2 = Combinators.square false (50, 100) 50 

// a test triangle
let triangle1 = 
    Combinators.triangle false 
        (150, 200) (150, 150) (250, 200)

// compose the basic elements into a picture
let scence = Combinators.compose [square1; square2; triangle1]

// create the display form
let form = new EvalForm([scence, Color.Red])

// show the form
Application.Run form
