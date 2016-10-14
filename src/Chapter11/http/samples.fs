#light
open System
open System.Diagnostics
open System.Net
open System.Xml

/// makes a http request to the given url 
let getUrlAsXml (url: string) =
    let request = WebRequest.Create(url)
    let response = request.GetResponse()
    let stream = response.GetResponseStream()
    let xml = new XmlDocument()
    xml.Load(stream)
    xml

/// the url we interested in
let url = "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/sci/tech/rss.xml"

/// main application function
let main() =
    // read the rss fead
    let xml = getUrlAsXml url
    
    // write out the tiles of all the news items
    let nodes = xml.SelectNodes("/rss/channel/item/title")
    for i in 0 .. (nodes.Count - 1) do
        printf "%i. %s\r\n" (i + 1) (nodes.[i].InnerText)
    
    // read the number the user wants from the console
    let item = int(Console.ReadLine())

    // find the new url
    let newUrl =
        let xpath = sprintf "/rss/channel/item[%i]/link" item
        let node = xml.SelectSingleNode(xpath)
        node.InnerText
        
    // start the url using the shell, this automaticall opens 
    // the default browser
    let procStart = new ProcessStartInfo(UseShellExecute = true,
                                         FileName = newUrl)
    let proc = new Process(StartInfo = procStart)
    proc.Start() |> ignore

do main()