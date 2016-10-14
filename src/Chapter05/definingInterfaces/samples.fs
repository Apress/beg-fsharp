module Strangelights.Samples1
// an interface "IUser" 
type IUser =
    // hashs the users password and checks it against
    // the known hash
    abstract Authenticate: evidence: string -> bool
    // gets the users logon message
    abstract LogonMessage: unit -> string

let logon (user: IUser) =
    // authenticate user and print appropriate message
    if user.Authenticate("badpass") then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"