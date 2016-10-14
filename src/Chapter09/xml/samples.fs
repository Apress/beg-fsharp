#light
open System.Xml

// create an xml dom object
let fruitsDoc =
    let temp = new XmlDocument()
    temp.Load("fruits.xml")
    temp
    
// select a list of nodes from the xml dom
let fruits = fruitsDoc.SelectNodes("/fruits/*")

// print out the name and text from each node
for x in fruits do
    printfn "%s = %s " x.Name x.InnerText
