#light
open System.Drawing
open System.Windows.Forms

let form =
    // create a new form setting the minimum size
    let temp = new Form(MinimumSize = new Size(96, 96))

    // repaint the form when it is resize
    temp.Resize.Add (fun _ -> temp.Invalidate())

    // a brush to provide the shapes color
    let brush = new SolidBrush(Color.Red)
    temp.Paint.Add (fun e ->
        // calculate the width and height of the shape
        let width, height = temp.Width - 64, temp.Height - 64
        // draw the required shape
        e.Graphics.FillPie (brush, 32, 32, width, height, 0, 290))

    // return the form to the top level
    temp

Application.Run(form)