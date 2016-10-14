#light

open System

let main() =
    use client = new GreetingServiceClient()
    while true do
        printfn "%s" (client.Greet("Rob"))
        Console.ReadLine() |> ignore
            
    use client = new GreetingServiceClient()
    printfn "%s" (client.Greet("Rob"))
    Console.ReadLine() |> ignore

do main()