// give an alias to the Array3D module
module ArrayThreeD = Microsoft.FSharp.Collections.Array3D

// create an matrix using the module alias
let matrix = 
    ArrayThreeD.create 3 3 3 1
