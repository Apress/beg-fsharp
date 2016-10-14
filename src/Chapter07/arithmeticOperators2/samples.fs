type person = { name : string ; favoriteColor : string }

let robert2 = { name = "Robert" ; favoriteColor = "Red" }
let robert3 = { name = "Robert" ; favoriteColor = "Green" }

printfn "(robert2 > robert3): %b" (robert2 > robert3)