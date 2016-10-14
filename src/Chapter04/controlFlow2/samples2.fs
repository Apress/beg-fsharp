#light
// a Ryunosuke Akutagawa haiku array
let ryunosukeAkutagawa = [| "Green "; "frog, ";
    "Is "; "your "; "body "; "also ";
    "freshly "; "painted?" |]

// for loop over the array printing each element
for index = 0 to Array.length ryunosukeAkutagawa - 1 do
    printf "%s " ryunosukeAkutagawa.[index]