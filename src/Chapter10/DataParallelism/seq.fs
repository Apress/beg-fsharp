namespace Strangelights.Extensions
open System
open System.Linq

// Import a small number of functions from ParallelLinq
module PSeq =
    // helper function to convert an ordinary seq (IEnumerable) into a IParallelEnumerable
    let asParallel list: IParallelEnumerable<_> = ParallelQuery.AsParallel(list)
    // the parallel map function we going to test
    let map f list = ParallelEnumerable.Select(asParallel list, new Func<_, _>(f))
    
    // other parallel functions you may consider using
    let reduce f list = ParallelEnumerable.Aggregate(asParallel list, new Func<_, _, _>(f))
    let fold f acc list = ParallelEnumerable.Aggregate(asParallel list, acc, new Func<_, _, _>(f))