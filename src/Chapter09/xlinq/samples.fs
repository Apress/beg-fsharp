#light
open System
open System.Linq
open System.Reflection
open System.Xml.Linq


// define easier access to LINQ methods
let select f s = Enumerable.Select(s, new Func<_,_>(f))
let where f s = Enumerable.Where(s, new Func<_,_>(f))
let groupBy f s = Enumerable.GroupBy(s, new Func<_,_>(f))
let orderBy f s = Enumerable.OrderBy(s, new Func<_,_>(f))
let count s = Enumerable.Count(s)

// query string methods using functions
let namesByFunction =
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic)
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> new XElement(XName.Get(m.Key), count m))
    |> orderBy (fun e -> int e.Value)

// create an xml document with the overloads data
let overloadsXml =
    new XElement(XName.Get("MethodOverloads"), namesByFunction)

// print the xml string    
printfn "%s" (overloadsXml.ToString())