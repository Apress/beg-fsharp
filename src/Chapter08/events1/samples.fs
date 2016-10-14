#light
open System.Windows.Forms
let form =
    // create a new form
    let temp = new Form()
    
    // subscribe the mouse click event filtering so it only 
    // reacts to the left button
    temp.MouseClick
    |> Event.filter (fun e -> e.Button = MouseButtons.Left)
    |> Event.add (fun _ -> MessageBox.Show("Left button") |> ignore)
    
    // return the form
    temp
    
Application.Run(form)