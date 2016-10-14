// write to a string
let s = Printf.sprintf "Hello %s\r\n" "string"
printfn "%s" s
// prints the string to the given channel
Printf.fprintf stdout "Hello %s\r\n" "channel"
// create a string that will be placed
// in an exception message
Printf.failwithf "Hello %s" "exception"