#light
// a Shuson Kato hiaku array (backwards)
let shusonKato = [| "watching."; "been "; "have ";
    "children "; "three "; "my "; "realize "; "and ";
    "ant "; "an "; "kill "; "I ";
    |]

// loop over the array backwards printing each word    
for index = Array.length shusonKato - 1 downto 0 do
    printf "%s " shusonKato.[index]