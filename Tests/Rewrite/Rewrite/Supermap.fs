module Supermap

/// Map each value in the list.
/// For each value of the original list, you can specify not one, but several values ​​to which it should be replaced.
let rec supermap list f =
    match list with
    | [] -> []
    | head :: tail -> (f head) @ (supermap tail f)