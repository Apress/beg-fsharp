#light
open Gtk

let main() =
     // initalize the GTK environment
     Application.Init()
 
     // create the window
     let win = new Window("GTK# and F# Application")
     // set the windows size
     win.Resize(400, 400)
     
     // create a label     
     let label = new Label()
     
     // create a button and subscribe to 
     // its clicked event
     let button = new Button(Label = "Press Me!")
     button.Clicked.Add(fun _ -> 
        label.Text <- "Hello World.")
     
     // create a new vbox and add the sub controls
     let vbox = new VBox()
     vbox.Add(label)
     vbox.Add(button)
     
     // add the vbox to the window
     win.Add(vbox)
     
     // show the window
     win.ShowAll()
     
     // close the event loop when the window closes
     win.Destroyed.Add(fun _ -> Application.Quit())
     
     // start the event loop
     Application.Run()
     
do main()