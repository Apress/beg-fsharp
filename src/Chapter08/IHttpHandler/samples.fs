#light
namespace Strangelights.HttpHandlers
open System.Web

// a http handler class
type SimpleHandler() =
    interface IHttpHandler with
        // tell the ASP.NET runtime if the handler can be reused
        member x.IsReusable = false
        // The method that will be called when processing a
        // HTTP request
        member x.ProcessRequest(c : HttpContext) =
            c.Response.Write("<h1>Hello World</h1>")

