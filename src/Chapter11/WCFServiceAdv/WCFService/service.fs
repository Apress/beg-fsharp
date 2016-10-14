#light
open System
open System.IO
open System.Drawing 
open System.ServiceModel
open System.Windows.Forms

// interface that defines our contract
[<ServiceContract
    (Namespace = 
        "http://strangelights.com/FSharp/Foundations/WCFImageService")>]
type IImageService =
    [<OperationContract>]
    abstract ReceiveImage : image:array<Byte> -> unit

// an event to signal the arrival of an image
let newImgEvent =
        new Event<Bitmap>()

// a service that implements our contract
type ImageService() =
    interface IImageService with
        member x.ReceiveImage( image ) =
            let memStream = new MemoryStream(image) 
            let bitmap = new Bitmap(memStream)
            newImgEvent.Trigger bitmap

// create a service host
let myServiceHost = 
    let baseAddress = new Uri("http://localhost:8080/service")

    let temp = new ServiceHost((typeof<ImageService>), [|baseAddress|])

    let binding = 
        let temp = new WSHttpBinding(Name = "binding1")
        temp.HostNameComparisonMode <- 
            HostNameComparisonMode.StrongWildcard
        temp.Security.Mode <- SecurityMode.Message
        temp.ReliableSession.Enabled <- false
        temp.TransactionFlow <- false
        temp

    temp.AddServiceEndpoint(typeof<IImageService>, binding, baseAddress) 
    |> ignore
    temp

// open the service host
myServiceHost.Open()

// create a new form
let form = new Form()

// add handler to the event that changes the background image
newImgEvent.Publish.Add(fun img -> 
    form.BackgroundImage <- img)

// show the form
[<STAThread>]
do Application.Run(form)