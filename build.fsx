open System
open System.IO
open System.Xml
open System.Diagnostics

let path = Path.Combine(__SOURCE_DIRECTORY__, "src") //fsi.CommandLineArgs.[1]

let files = Directory.GetFiles(path, "*.fsproj", SearchOption.AllDirectories)
let files' = Seq.take 3 files

let treatWarningsAs() =
    for file in files do
        let doc = new XmlDocument()
        doc.Load(file)
        let nsmgr = new XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")
        let node = doc.SelectSingleNode("/msb:Project/msb:PropertyGroup", nsmgr)
        let warnAsErr = doc.CreateElement("TreatWarningsAsErrors", "http://schemas.microsoft.com/developer/msbuild/2003")
        warnAsErr.InnerText <- "true"
        node.AppendChild(warnAsErr) |> ignore
        let warnLevel = doc.CreateElement("WarningLevel", "http://schemas.microsoft.com/developer/msbuild/2003")
        warnLevel.InnerText <- "4"
        node.AppendChild(warnLevel) |> ignore
        doc.Save(file)

let fixupMsBuildPaths() =
    for file in files do
        let doc = new XmlDocument()
        doc.Load(file)
        let nsmgr = new XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")
        let node = doc.SelectSingleNode("/msb:Project/msb:Import/@Project", nsmgr)
        node.InnerText <- @"$(MSBuildExtensionsPath32)\..\Microsoft F#\v4.0\Microsoft.FSharp.Targets"
        doc.Save(file)


        
let fixUpNames() =
    for file in files do
        let doc = new XmlDocument()
        doc.Load(file)
        let nsmgr = new XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")
        let nameNode = doc.SelectSingleNode("/msb:Project/msb:PropertyGroup/msb:Name", nsmgr)
        let assemNameNode = doc.SelectSingleNode("/msb:Project/msb:PropertyGroup/msb:AssemblyName", nsmgr)
        let name = Path.GetFileNameWithoutExtension(file)
        nameNode.InnerText <- name
        assemNameNode.InnerText <- name
        doc.Save(file)


let args = ""//"/t:Clean"

let windir = Environment.GetEnvironmentVariable("windir")
let msbuild = Path.Combine(windir, @"Microsoft.NET\Framework\v4.0.21006\msbuild.exe")
//let msbuild = Path.Combine(Path.GetDirectoryName(typeof<obj>.Assembly.Location), "msbuild.exe")

let buildAll() =
    try File.Delete(path + "summary.txt") with _ -> ();
    let mutable count = 0
    for file in files do
        let procStart = new ProcessStartInfo(FileName = msbuild, 
                                             WorkingDirectory = Path.GetDirectoryName(file),
                                             Arguments = Path.GetFileName(file) + " " + args,
                                             UseShellExecute = false,
                                             RedirectStandardOutput = true)
        let proc = new Process(StartInfo = procStart)
        proc.Start() |> ignore
        let out = proc.StandardOutput.ReadToEnd()
        proc.WaitForExit()
        let success = if proc.ExitCode = 0 then count <- count + 1; "built" else "broken"
        let dir = Path.GetDirectoryName(Path.GetDirectoryName(file))
        let filename = Path.GetFileNameWithoutExtension(file);
        let filename = sprintf "%s_%s.log" filename success
        File.WriteAllText(Path.Combine(dir, filename), out)
        File.AppendAllText(path + "\summary.txt", sprintf "%s: %s%s" success file Environment.NewLine) 
    File.AppendAllText(path + "\summary.txt", (sprintf "%i / %i" count  files.Length))

buildAll()

let deleteFiles ext =
    let files = Directory.GetFiles(path, Printf.sprintf "*.%s" ext, SearchOption.AllDirectories)
    for file in files do
        File.Delete file

deleteFiles "log"
deleteFiles "suo"

let deleteDirs dir =
    let dirs = Directory.GetDirectories(path, dir, SearchOption.AllDirectories)
    for dir in dirs do
        Directory.Delete(dir, true)

deleteDirs "obj"
deleteDirs "bin"
