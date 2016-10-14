let myArray = [|1; 2; 3|]

let myNewCollection =
    myArray |>
    Seq.map (fun x -> x * 2)
    
printfn "%A" myArray

myNewCollection |> Seq.iter (fun x -> printf "%i ... " x)