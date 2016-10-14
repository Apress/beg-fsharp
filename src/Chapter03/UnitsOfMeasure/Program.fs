﻿// define some units of measure
[<Measure>]type litre
[<Measure>]type pint

// define some volumens
let vol1 = 2.5<litre>
let vol2 = 2.5<pint>

// define the ratio of pints to litres
let ratio =  1.0<litre> / 1.76056338<pint>

// a function to convert prints to litres
let convertPintToLitre pints =
    pints * ratio

// preforme the conversion and add the values
let newVol = vol1 + (convertPintToLitre vol2)