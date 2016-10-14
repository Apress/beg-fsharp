#light
open System.Drawing
open System.Windows.Forms

// create a new form
let form = new Form(BackColor = Color.Purple, Text = "Introducing WinForms")

// show the form
Application.Run(form)