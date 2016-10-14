module Strangelights.Sample1
open System.Web.Security

// give shorte name to password hashing method
let hash = FormsAuthentication.HashPasswordForStoringInConfigFile

// a class that represents a user
// it's constructor takes two parameters, the user's 
// name and a hash of their password
type User = class
    // the class' fields
    val name: string
    val passwordHash: string
    
    // the class' constructor
    new (name, passwordHash) = 
        { name = name; passwordHash = passwordHash }

    // hashs the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash (password, "sha1")
        x.passwordHash = hashResult

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" x.name
end