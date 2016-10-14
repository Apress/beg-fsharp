module Strangelights.Sample2
open System.Drawing
open System.Windows.Forms
open Strangelights.GraphicDSL

// define a function that can draw a 6 sided star
let star (x, y) size =
    let offset = size / 2
    // calculate the first triangle
    let t1 = 
        Combinators.triangle false 
            (x, y - size - offset)
            (x - size, y + size - offset) 
            (x + size, y + size - offset)
    // calculate another inverted triangle
    let t2 = 
        Combinators.triangle false 
            (x, y + size + offset) 
            (x + size, y - size + offset) 
            (x - size, y - size + offset)
    // compose the triangles
    Combinators.compose [ t1; t2 ]    

// the points where stars should be plotted
let points = [ (10, 20); (200, 10); 
               (30, 160); (100, 150); (190, 150);
               (20, 300); (200, 300);  ]

// compose the stars into a single scene
let scence = 
    Combinators.compose 
        (List.map (fun pos -> star pos 5) points)

// show the scene in red on the EvalForm
let form = new EvalForm([scence, Color.Red], 
                        Width = 260, Height = 350)

// show the form
Application.Run form