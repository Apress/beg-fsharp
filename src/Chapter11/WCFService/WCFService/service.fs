#light
namespace Strangelights.Services
open System.ServiceModel

// the service contract
[<ServiceContract
    (Namespace = 
        "http://strangelights.com/FSharp/Foundations/WCFServices")>]
type IGreetingService =
    [<OperationContract>]
    abstract Greet : name:string -> string

// the service implementation
type GreetingService() =
    interface IGreetingService with
        member x.Greet(name)  = "Hello: " + name
