let event = new Event<string>()
event.Publish.Add(fun x -> printfn "%s" x)
event.Trigger "hello"