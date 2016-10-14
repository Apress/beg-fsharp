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

// create a new instance of our user class
let user = User("Robert", "AF73C586F66FDC99ABF1EADB2B71C5E46C80C24A")

        
let main() =
    // authenticate user and print appropriate message
    if user.Authenticate("badpass") then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"

do main()