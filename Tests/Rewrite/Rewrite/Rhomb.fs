module Rhomb

/// Creates a rhomb of `*` characters with side `n`
let createRhombLines n =
    let spaceCount k = abs (n - 1 - k)
    let starCount k = 2 * (n - spaceCount k) - 1
    [0..2 * (n - 1)] |> List.map (fun k -> 
        String.replicate (spaceCount k) " " + String.replicate (starCount k) "*" + String.replicate (spaceCount k) " ")

/// Prints the rhomb with side `n`.
let printRhomb n =
    createRhombLines n
    |> List.iter (printfn "%s")