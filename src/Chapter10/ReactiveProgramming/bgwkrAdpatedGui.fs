module Strangelights.Sample3
open Strangelights.Extensions
open System
open System.ComponentModel
open System.Windows.Forms
open System.Numerics

// define a type to hold the results
type Result =
    { Input: int;
      Fibonacci: BigInteger; }

let form =
    let form = new Form()
    // input text box
    let input = new TextBox()
    // button to launch processing
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // list to hold the results
    let results = new BindingList<Result>()
    // data grid view to display multiple results
    let output = new DataGridView(Top = input.Bottom + 10, Width = form.Width, 
                                  Height = form.Height - input.Bottom + 10,
                                  Anchor = (AnchorStyles.Top ||| AnchorStyles.Left ||| 
                                            AnchorStyles.Right ||| AnchorStyles.Bottom),
                                  DataSource = results)

    // create and run a new background worker
    let runWorker() =
        let background = new BackgroundWorker()
        // parse the input to an int
        let input = Int32.Parse(input.Text)
        // add the "work" event handler
        background.DoWork.Add(fun ea ->
            ea.Result <- (input, fib input)) 
        // add the work completed event handler
        background.RunWorkerCompleted.Add(fun ea ->
            let input, result = ea.Result :?> (int * bigint)
            results.Add({ Input = input; Fibonacci = result; }))
        // start the worker off
        background.RunWorkerAsync()
 
    // hook up creating and running the worker to the button   
    button.Click.Add(fun _ -> runWorker())
    // add the controls
    let dc c = c :> Control
    form.Controls.AddRange([|dc input; dc button; dc output |])
    // return the form
    form

// show the form
do Application.Run(form)
