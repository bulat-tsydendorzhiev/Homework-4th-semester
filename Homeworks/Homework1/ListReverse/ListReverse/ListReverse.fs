module ListReverse

let reverseList list =
    let rec reverseListRecursive ls acc =
        match ls with
        | [] -> acc
        | head :: tail -> reverseListRecursive tail (head :: acc)
    reverseListRecursive list []
