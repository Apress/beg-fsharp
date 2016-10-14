let listOfList = [[2; 3; 5]; [7; 11; 13]; [17; 19; 23; 29]]

let rec concatList l =
    if List.isEmpty l then
        []
    else
        let head = List.head l
        let tail = List.tail l
        head @ (concatList tail)

let primes = concatList listOfList

printfn "%A" primes