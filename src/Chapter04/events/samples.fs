#light
open System.Windows.Forms
open System.Timers

let timer =
    // define the timer
    let temp = new Timer(Interval = 3000.0,
                         Enabled = true)
                         
    // a counter to hold the current message
    let messageNo = ref 0
    
    // the messages to be shown
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying"; 
                     "very"; "quickly" ]
                     
    // add an event to the timer
    temp.Elapsed.Add(fun _ ->
        // show the message box
        MessageBox.Show(List.nth messages !messageNo) |> ignore
        // update the message counter
        messageNo := (!messageNo + 1) % (List.length messages))
        
    // return the timer to the top level
    temp

// print a message then wait for a user action    
printfn "Whack the return to finish!"
System.Console.ReadLine() |> ignore
timer.Enabled <- false
