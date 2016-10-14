#light
open System.Configuration

// open the machine config
let config =
    ConfigurationManager.OpenMachineConfiguration()

// print the names of all sections
for x in config.Sections do
    printfn "%s" x.SectionInformation.Name