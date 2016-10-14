#light
open System

// a date list
let importantDates = [ new DateTime(1066,10,14); 
                       new DateTime(1999,01,01); 
                       new DateTime(2999,12,31) ]

// printing function
let printInt = printf "%i "

// case 1: type annotation required
List.iter (fun (d: DateTime) -> printInt d.Year) importantDates

// case 2: no type annotation required
importantDates |> List.iter (fun d -> printInt d.Year)
