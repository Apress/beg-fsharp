open System

let mailbox = 
    MailboxProcessor.Start(fun mb ->
        let rec loop x =
            async { let! msg = mb.Receive()
                    let x = x + msg
                    printfn "Running total: %i - new value %i" x msg
                    return! loop x }
        loop 0)
        
mailbox.Post(1)
mailbox.Post(2)
mailbox.Post(3)

Console.ReadLine() |> ignore
