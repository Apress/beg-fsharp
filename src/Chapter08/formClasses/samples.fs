#light
open System
open System.Windows.Forms

// a class that derives from "Form" and add some user controls
type MyForm() as x =
    inherit Form(Width=174, Height=64)

    // create some controls to add the form
    let label = new Label(Top=8, Left=8, Width=40, Text="Input:")
    let textbox = new TextBox(Top=8, Left=48, Width=40)
    let button = new Button(Top=8, Left=96, Width=60, Text="Push Me!")
    
    // add a event to the button
    do button.Click.Add(fun _ ->
        let form = new MyForm(Text=textbox.Text)
        form.Show())

    // add the controls to the form
    do x.Controls.Add(label)
    do x.Controls.Add(textbox)
    do x.Controls.Add(button)
    
    // expose the text box as a property
    member x.Textbox = textbox

// create an new instance of our form
let form =
    let temp = new MyForm(Text="My Form")
    temp.Textbox.Text <- "Next!"
    temp
    
[<STAThread>]
do Application.Run(form)
