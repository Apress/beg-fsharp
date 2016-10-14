open System.Windows.Forms

let anchor = AnchorStyles.Left ||| AnchorStyles.Left

printfn "test AnchorStyles.Left: %b"
    (anchor &&& AnchorStyles.Left <> enum 0)
printfn "test AnchorStyles.Right: %b"
    (anchor &&& AnchorStyles.Right <> enum 0)