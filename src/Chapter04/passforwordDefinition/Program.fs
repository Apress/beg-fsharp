#light

// the definition of the pipe-forward operator
let (|>) x f = f x

// pipe the parameter 0.5 to the sin function
let result = 0.5 |> System.Math.Sin