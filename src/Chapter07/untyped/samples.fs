#light
open System.Collections

let arrayList =
    let temp = new ArrayList()
    temp.AddRange([| 1; 2; 3 |])
    temp

// Note: this is no longer supported use for x in collection instead
//let doubledArrayList =
//    arrayList |>
//    Seq.untyped_map (fun x -> x * 2)
//    
//doubledArrayList |> Seq.untyped_iter (fun x -> printf "%i ... " x)

let doubledSeq =
    seq { for x in arrayList -> (x :?> int) * 2 }

doubledSeq |> Seq.iter (fun x -> printf "%i ... " x)
