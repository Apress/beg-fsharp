#light
open System
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open System.Windows.Forms

// creates a connections then executes the given command on it
let createDataSet commandString =
    // read the connection string
    let connectionSetting =
        ConfigurationManager.ConnectionStrings.["MyConnection"]

    // create a data adapter to fill the dataset
    let adapter = new SqlDataAdapter(commandString, connectionSetting.ConnectionString)

    // create a new data set and fill it
    let ds = new DataSet()
    adapter.Fill(ds) |> ignore
    ds

// create the data set that will be bound to the form
let dataSet = createDataSet "select top 10 * from Person.Contact"

// create a form containing a data bound data grid view
let form =
    let temp = new Form()
    let grid = new DataGridView(Dock = DockStyle.Fill)
    temp.Controls.Add(grid)
    grid.DataSource <- dataSet.Tables.[0]
    temp

// show the form    
Application.Run(form)