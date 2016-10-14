#light
try
    // look at current time and raise an exception
    // based on whether the second is a multiple of 3
    if System.DateTime.Now.Second % 3 = 0 then
        raise (new System.Exception())
    else
        raise (new System.ApplicationException())
with
| :? System.ApplicationException ->
    // this will handle "ApplicationException" case
    printfn "A second that was not a multiple of 3"
| _ ->
    // this will handle all other exceptions
    printfn "A second that was a multiple of 3"
