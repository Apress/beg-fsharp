module Strangelights.Sample
open System
open System.Drawing
open System.Windows.Forms

// create a new instance of a number control
let makeNumberControl (n: int) =
    { new Control(Tag = n, Width = 32, Height = 16) with
          // override the controls paint method to draw the number
          override x.OnPaint(e) =
              let font = new Font(FontFamily.Families.[2], 12.0F)
              e.Graphics.DrawString(n.ToString(),
                                    font,
                                    Brushes.Black,
                                    new PointF(0.0F, 0.0F))

      // implement the IComparable interface so the controls
      // can be compared
      interface IComparable with
          member x.CompareTo(other) =
              let otherControl = other :?> Control in
              let n1 = otherControl.Tag :?> int in
              n.CompareTo(n1) }

