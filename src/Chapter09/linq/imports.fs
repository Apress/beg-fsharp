module Strangelights.LinqImports
open System
open System.Linq

// define easier access to LINQ methods
let select f s = Enumerable.Select(s, new Func<_,_>(f))
let where f s = Enumerable.Where(s, new Func<_,_>(f))
let groupBy f s = Enumerable.GroupBy(s, new Func<_,_>(f))
let orderBy f s = Enumerable.OrderBy(s, new Func<_,_>(f))
let count s = Enumerable.Count(s)
