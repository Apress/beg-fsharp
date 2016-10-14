#light
open System
open System.Drawing
open System.Windows.Forms

// create a new instance of a number control
let makeNumberControl (n: int) =
    { new TextBox(Tag = n, Width = 32, Height = 16, Text = n.ToString())
          // implement the IComparable interface so the controls
          // can be compared
          interface IComparable with
              member x.CompareTo(other) =
                  let otherControl = other :?> Control in
                  let n1 = otherControl.Tag :?> int in
                  n.CompareTo(n1) }

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
