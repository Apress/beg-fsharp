let anotherObject = ("This is a string" :> obj)

if (anotherObject :? string) then
    printfn "This object is a string"
else
    printfn "This object is not a string"
    
if (anotherObject :? string[]) then
    printfn "This object is a string array"
else
    printfn "This object is not a string array"