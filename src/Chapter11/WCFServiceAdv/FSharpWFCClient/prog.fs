#light
open System
open System.IO
open System.Windows.Forms

// create a form for sending images
let form =
    // create the form itself
    let temp = new Form(Width=272, Height=64)
    // text box for path to the image
    let imagePath = new TextBox(Top=8, Left=8, Width=128)
    // browse button to allow the user to search for files
    let browse = new Button(Top=8, Width=32, Left=8+imagePath.Right, Text = "...")
    browse.Click.Add(fun _ ->
        let dialog = new OpenFileDialog()
        if dialog.ShowDialog() = DialogResult.OK then
            imagePath.Text <- dialog.FileName)
    
    // send button to send the image to the server
    let send = new Button(Top=8, Left=8+browse.Right, Text = "Send")
    send.Click.Add(fun _ ->
        // open and send the file
        let buffer = File.ReadAllBytes(imagePath.Text)
        let service = new ImageServiceClient()
        service.ReceiveImage(buffer))

    // add the controls and return the form
    temp.Controls.Add(imagePath)
    temp.Controls.Add(browse)
    temp.Controls.Add(send)
    temp

// show the form
[<STAThread>]
do Application.Run(form)