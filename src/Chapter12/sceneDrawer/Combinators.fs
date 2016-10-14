namespace Strangelights.GraphicDSL
open System.Drawing

// represents a point within the scene
type Position = int * int

// represents the basic shapes that will make up the scene
type Shape =
    | Line of Position * Position
    | Polygon of List<Position>
    | CompersiteShape of List<Shape>

// allows us to give a color to a shape
type Element = Shape * Color

module Combinators =
    // allows us to compose a list of elements into a 
    // single shape
    let compose shapes = CompersiteShape shapes

    // a simple line made from two points
    let line pos1 pos2 = Line (pos1, pos2)
    
    // a line composed of two or more points
    let lines posList =
        // grab first value in the list
        let initVal = 
            match posList with 
            | first :: _ -> first
            | _ -> failwith "must give more than one point"
        // creates a new link in the line
        let createList (prevVal, acc) item = 
            let newVal = Line(prevVal, item)
            item, newVal :: acc
        // folds over the list accumlating all points into a 
        // list of line shapes
        let _, lines = List.fold createList (initVal, []) posList
        // compose the list of lines into a single shape
        compose lines
    
    // a polygon defined by a set of points
    let polygon posList = Polygon posList    
    
    // a triangle that can be either hollow or filled
    let triangle filled pos1 pos2 pos3 =
        if filled then
            polygon [ pos1; pos2; pos3; pos1 ]
        else
            lines [ pos1; pos2; pos3; pos1 ]

    // a square that can either be hollow or filled
    let square filled (top, right) size =
        let pos1, pos2 = (top, right), (top, right + size)
        let pos3, pos4 = (top + size, right + size), (top + size, right)
        if filled then
            polygon [ pos1; pos2; pos3; pos4; pos1 ]
        else
            lines [ pos1; pos2; pos3; pos4; pos1 ]

