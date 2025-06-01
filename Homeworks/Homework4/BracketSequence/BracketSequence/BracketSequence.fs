module BracketSequence

let isOpeningBracket bracket = bracket = '(' || bracket = '[' || bracket = '{'

let isClosingBracket bracket = bracket = ')' || bracket = ']' || bracket = '}'

let isCorrectPairOfBrackets opening closing =
    match opening with
    | '(' -> closing = ')'
    | '[' -> closing = ']'
    | '{' -> closing = '}'
    | _ -> false

/// Checks the bracket balance in a string.
let isBalanced (str: string) =
    let rec isBalancedInternal openings i =
        if i >= str.Length then
            List.isEmpty openings
        else
            let char = str[i]
            match char with
            | c when isOpeningBracket c -> isBalancedInternal (char :: openings) (i + 1)
            | c when isClosingBracket c ->
                if (List.isEmpty openings |> not) && isCorrectPairOfBrackets (List.head openings) c then
                    isBalancedInternal (List.tail openings) (i + 1)
                else
                    false
            | _ -> isBalancedInternal openings (i + 1)

    isBalancedInternal [] 0