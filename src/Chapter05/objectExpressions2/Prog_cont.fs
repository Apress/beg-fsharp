#light
open System
open System.Windows.Forms
open Strangelights.Sample

// a sorted array of the numbered controls
let numbers =
    // initalize the collection
    let temp = new ResizeArray<Control>()
    // initalize the random number generator
    let rand = new Random()
    // add the controls collection
    for index = 1 to 10 do
        temp.Add(makeNumberControl (rand.Next(100)))
    // sort the collection
    temp.Sort()
    // layout the controls correctly
    let height = ref 0
    temp |> Seq.iter
        (fun c ->
            c.Top <- !height
            height := c.Height + !height)
    // return collection as an array
    temp.ToArray()

// create a form to show the number controls    
let numbersForm =
    let temp = new Form() in
    temp.Controls.AddRange(numbers);
    temp

// show the form
[<STAThread>]
do Application.Run(numbersForm)
