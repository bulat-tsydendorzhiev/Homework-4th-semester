module Factorial

let factorial number =
    let rec factorialRecursive acc i =
        match i with
        | 0 -> Some(acc)
        | n -> factorialRecursive (acc * n) (i - 1)

    if number < 0 then None
    else factorialRecursive 1 number
