module Strangelights.Sample
// a abstract class that represents a user
// it's constructor takes one parameters, 
// the user's name
[<AbstractClass>]
type User(name) =
    // the implmentation of this method should hashs the 
    // users password and checks it against the known hash
    abstract Authenticate: evidence: string -> bool

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

