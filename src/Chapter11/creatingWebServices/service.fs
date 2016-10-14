#light
namespace Strangelights.WebServices

open System.Web.Services

[<WebService(Namespace = 
    "http://strangelights.com/FSharp/Foundations/WebServices")>]
type Service =
    inherit WebService
    new() = {}
    [<WebMethod(Description = "Perfoms integer addition")>]
    member service.Addition (x: int, y: int) = x + y
