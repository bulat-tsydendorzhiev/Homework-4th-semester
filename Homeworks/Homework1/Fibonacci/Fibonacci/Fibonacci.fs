module Fibonacci

let fibonacci n =
    let rec fibonacciRecursive current next i =
        match i with
        | 0 -> Some(current)
        | _ -> fibonacciRecursive next (current + next) (i - 1)

    if n < 0 then None
    else fibonacciRecursive 0 1 n
