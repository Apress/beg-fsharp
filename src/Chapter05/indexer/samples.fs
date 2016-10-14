#light
// a class with indexers
type Indexers(vals:string[]) =
    // a normal indexer
    member x.Item
        with get y = vals.[y]
        and set y z = vals.[y] <- z
    // an indexer with an unusual name
    member x.MyString
        with get y = vals.[y]
        and set y z = vals.[y] <- z

// create a new instance of the indexer class
let index = new Indexers [|"One"; "Two"; "Three"; "Four"|]

// test the set indexers
index.[0] <- "Five";
index.Item(2) <- "Six";
index.MyString(3) <- "Seven";

// test the get indexers
printfn "%s" index.[0]
printfn "%s" (index.Item(1))
printfn "%s" (index.MyString(2))
printfn "%s" (index.MyString(3))
