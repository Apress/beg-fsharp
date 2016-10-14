open System

let readInt() = int (Console.ReadLine())

let mathsPuzzle() =
    printfn "Enter day of the month on which you were born: "
    let input = readInt()
    let x = input * 4 // Multiply it by 4
    let x = x + 13 // Add 13
    let x = x * 25 // Multiply the result by 25
    let x = x - 200 // Subtract 200
    printfn "Enter number of the month you were born: "
    let input = readInt()
    let x = x + input
    let x = x * 2 // Multiply by 2
    let x = x - 40 // Subtract 40
    let x = x * 50 // Multiply the result by 50
    printfn "Enter last two digits of the year of your birth: "
    let input = readInt()
    let x = x + input
    let x = x - 10500 // Finally, subtract 10,500
    printf "Date of birth (ddmmyy): %i" x
    
mathsPuzzle()
