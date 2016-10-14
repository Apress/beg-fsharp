// sequence of tuples representing points
let squarePoints n =
    seq { for x in 1 .. n do
            for y in 1 .. n do 
                yield x, y }

// print the sequence
printfn "%A" (squarePoints 3)