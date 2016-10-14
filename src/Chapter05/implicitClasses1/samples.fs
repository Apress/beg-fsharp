#light
type Counter(start, increment, length) =
    let finish = start + length
    let mutable current = start
    member obj.Current = current
    member obj.Increment() =
        if current > finish then failwith "finished!"
        current <- current + increment
