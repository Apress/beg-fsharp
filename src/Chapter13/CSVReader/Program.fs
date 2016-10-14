open System
open System.IO
open System.Collections
open System.Reflection
open Microsoft.FSharp.Reflection

// a class to read CSV values from a file
type CsvReader<'a>(filename) =
    // fail if the gernic type is no a tuple
    do if not (FSharpType.IsTuple(typeof<'a>)) then
         failwith "Type parameter must be a tuple"
    // get the elements of the tuple
    let elements = FSharpType.GetTupleElements(typeof<'a>)
    // create functions to parse a element of type t
    let getParseFunc t =
        match t with
        | _ when t = typeof<string> ->
            // for string types return a function that down
            // casts to an object
            fun x -> x :> obj
        | _  ->
            // for all other types test to see if they have a
            // Parse static method and use that
            let parse = t.GetMethod("Parse", 
                                    BindingFlags.Static ||| 
                                    BindingFlags.Public, 
                                    null, 
                                    [| typeof<string> |], 
                                    null)
            fun (s: string) ->
                parse.Invoke(null, [| box s |]) 
    // create a list of parse functions from the tuple's elements
    let funcs = Seq.map getParseFunc elements
    // read all lines from the file
    let lines = File.ReadAllLines filename
    // create a function parse each row
    let parseRow row = 
        let items =
            Seq.zip (List.ofArray row) funcs
            |> Seq.map (fun (ele, parser) -> parser ele)
        FSharpValue.MakeTuple(Array.ofSeq items, typeof<'a>)
    // parse each row cast value to the type of the given tuple
    let items = 
        lines 
        |> Seq.map (fun x -> (parseRow (x.Split(','))) :?> 'a)
        |> Seq.toList 
    // implement the generic IEnumerable<'a> interface
    interface seq<'a> with
        member x.GetEnumerator() = 
           let seq = Seq.ofList items
           seq.GetEnumerator()
    // implement the non-generic IEnumerable interface
    interface IEnumerable with
        member x.GetEnumerator() = 
           let seq = Seq.ofList items
           seq.GetEnumerator() :> IEnumerator

let reader = new CsvReader<int*int*int>("numbers.csv")

for x, y, z in reader do
    assert (x + y = z)
    printfn "%i + %i = %i" x y z