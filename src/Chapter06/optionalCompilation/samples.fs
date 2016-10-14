#light
open System.Windows.Forms

// define a form
let form = new Form()

// do something different depending if we're runing
// as a compiled program of as a script
#if COMPILED
Application.Run form
#else
form.Show()
#endif