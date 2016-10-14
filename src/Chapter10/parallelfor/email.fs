module Strangelights.Sample2
open System.Threading

let emails = [ "robert@strangelights.com"; "jon@doe.com";
               "jane@doe.com"; "venus@cats.com" ]

Parallel.ForEach(emails, (fun addr ->
    // code to create and send email goes here
    ()))