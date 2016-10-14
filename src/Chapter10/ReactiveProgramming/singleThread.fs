module Strangelights.Sample2
open Strangelights.Extensions
open System
open System.Windows.Forms

let form =
    let form = new Form()
    // input text box
    let input = new TextBox()
    // button to launch processing
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // label to display the result
    let output = new Label(Top = input.Bottom + 10, Width = form.Width, 
                           Height = form.Height - input.Bottom + 10,
                           Anchor = (AnchorStyles.Top ||| AnchorStyles.Left ||| 
                                     AnchorStyles.Right ||| AnchorStyles.Bottom))
    // do all the work when the button is clicked
    button.Click.Add(fun _ -> 
        output.Text <- Printf.sprintf "%A" (fib (Int32.Parse(input.Text)))) 
    // add the controls
    let dc c = c :> Control
    form.Controls.AddRange([|dc input; dc button; dc output |])
    // return the form
    form

// show the form
do Application.Run(form)