#light
open System.Xml

// list of animal data
let animals = [ "ants", "6"; "spiders", "8"; "cats", "4" ]

// create 
let animalsDoc =
    // create the xml dom object
    let temp = new XmlDocument()

    // create the root element and add it to the dom object
    let root = temp.CreateElement("animals")
    temp.AppendChild(root) |> ignore

    // iterate over the list of animals adding each one
    animals
    |> List.iter (fun x ->
        let element = temp.CreateElement(fst x)
        element.InnerText <- (snd x)
        root.AppendChild(element) |> ignore)

    // return the dom object
    temp

// save the animals doc to disk
animalsDoc.Save("animals.xml")