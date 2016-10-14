let event = new Event<string>()
let newEvent = event.Publish |> Event.filter (fun x -> x.StartsWith("H"))

newEvent.Add(fun x -> printfn "new event: %s" x)

event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"