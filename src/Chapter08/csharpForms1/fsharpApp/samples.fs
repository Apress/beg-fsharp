#light
open System.Windows.Forms
open Strangelights.Forms

// an infinite sequence of Fibonacci numbers
let fibs =
    (1,1) |> Seq.unfold
        (fun (n0, n1) ->
        Some(n0, (n1, n0 + n1)))
        
// a function to get the nth fibonacci number
let getFib n =
    Seq.nth n fibs
    
let form =
    // create a new instance of the form
    let temp = new FibForm()
    // add an event handler to the form's click event
    temp.Calculate.Click.Add
        (fun _ ->
            // convert input to an integer
            let n = int temp.Input.Text
            // caculate the apropreate fibonacci number
            let n = getFib n
            // display result to user
            temp.Result.Text <- string n)
    temp
    
Application.Run(form)