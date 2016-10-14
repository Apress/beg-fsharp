#light
open Strangelights.Samples.Helpers

// a class that represents a user
// it's constructor takes two parameters, the user's 
// name and a hash of their password
type User(name, passwordHash) =
    // hashs the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash (password, "sha1")
        passwordHash = hashResult

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // a static member that provides an alterative way
    // of creating the object        
    static member FromDB id =
        let name, ph = getUserFromDB id
        new User(name, ph)

let user = User.FromDB 1
