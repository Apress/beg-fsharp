#light
namespace Strangelights.WebServices

open System.Web.Services

// the web service class
[<WebService(Namespace = 
    "http://strangelights.com/FSharp/Foundations/DnaWebService")>]
type DnaWebService() =
    inherit WebService()
    
    // the web method
    [<WebMethod(Description = "Gets a representation of a yeast molecule")>]
    member x.GetYeastMolecule () =
        // the code that populates the yeast xml structure
        let tax = new taxonomy(domain = "Eukaryota", kingdom = "Fungi", 
                               phylum = "Ascomycota", ``class`` = "Saccharomycetes", 
                               order = "Saccharomycetales", 
                               family = "Saccharomycetaceae", 
                               genus = "Saccharomyces", 
                               species = "Saccharomyces cerevisiae")
        let id = new identity(name = "Saccharomyces cerevisiae tRNA-Phe",
                              taxonomy = tax)
        let yeast = new molecule(id = "Yeast-tRNA-Phe", identity = id)
        let numRange1 = new numberingrange(start = "1", Item = "10")
        let numRange2 = new numberingrange(start = "11", Item = "66")
        let numSys = new numberingsystem(id="natural", usedinfile=true)
        numSys.Items <- [|box numRange1; box numRange2|]
        let seqData = new seqdata()
        seqData.Value <- "GCGGAUUUAG CUCAGUUGGG AGAGCGCCAG ACUGAAGAUC 
          UGGAGGUCCU GUGUUCGAUC CACAGAAUUC GCACCA"
        let seq = new sequence(numberingsystem = [|numSys|], seqdata = seqData)
        yeast.sequence <- [|seq|]
        yeast