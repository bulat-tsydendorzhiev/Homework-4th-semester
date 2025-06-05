module Supermap

let rec supermap list f =
    match list with
    | [] -> []
    | head :: tail -> (f head) @ (supermap tail f)