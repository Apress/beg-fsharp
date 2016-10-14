let event = new Event<string>()
let newEvent = event.Publish |> Event.map (fun x -> "Mapped data: " + x)
newEvent.Add(fun x -> printfn "%s" x)

event.Trigger "Harry"
event.Trigger "Sally"