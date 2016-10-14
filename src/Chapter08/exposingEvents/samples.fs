#light
open System.Windows.Forms

// a form with addation LeftMouseClick event
type LeftClickForm() as x =
    inherit Form()
    // create the new event
    let event = new Event<MouseEventArgs>()
    
    // wire the new event up so it fires when the left
    // mouse button is clicked
    do x.MouseClick
        |> Event.filter (fun e -> e.Button = MouseButtons.Left)
        |> Event.add (fun e -> event.Trigger e)
    
    // expose the event as property
    [<CLIEvent>]
    member x.LeftMouseClick = event.Publish