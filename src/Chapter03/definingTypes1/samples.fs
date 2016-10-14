module Strangelights.Sample1
// define an organization with unique fields
type Organization1 = { boss: string; lackeys: string list }
// create an instance of this organization
let rainbow =
    { boss = "Jeffrey";
      lackeys = ["Zippy"; "George"; "Bungle"] }

// define two organization with over lapping fields
type Organization2 = { chief: string; underlings: string list }
type Organization3 = { chief: string; indians: string list }

// create an instance of Organisation2
let (thePlayers: Organization2) = 
    { chief = "Peter Quince"; 
      underlings = ["Francis Flute"; "Robin Starveling";
                    "Tom Snout"; "Snug"; "Nick Bottom"] }

// create an instance of Organisation3
let (wayneManor: Organization3) = 
    { chief = "Batman"; 
      indians = ["Robin"; "Alfred"] }