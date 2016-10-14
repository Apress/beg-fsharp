let event = new Event<string>()
let hData, nonHData = event.Publish |> Event.partition (fun x -> true) 

let x  = Event.partition


hData.Add(fun x -> printfn "H data: %s" x)
nonHData.Add(fun x -> printfn "None H data: %s" x)

event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"