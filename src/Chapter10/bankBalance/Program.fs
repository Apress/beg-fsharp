#light
open System
open System.Threading

let mutable balance = 100.0

let updateBalance() =
    let rand = new Random()
    for x in 0 .. 10000 do
        let amount = float (rand.Next(-50,  30))
        let balance' = balance + amount
        if balance' > 0. then
            balance <- balance'
        printfn "Balance: %f" balance
        if balance < 0. then
            printfn "overdrawn %f" balance
            failwith "overdrawn"

let multiThreadRun() =
    let threads = List.map (fun _ -> new Thread(fun () -> updateBalance())) [ 0 .. 4 ]
    threads |> List.iter (fun x -> x.Start())
    threads |> List.iter (fun x -> x.Join())

multiThreadRun()