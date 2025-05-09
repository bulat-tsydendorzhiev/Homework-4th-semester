module NumberSearch

let searchNumber list number =
    let rec searchNumberInternal ls i =
        match ls with
        | [] -> None
        | head :: tail -> 
            if head = number then Some(i)
            else searchNumberInternal tail (i + 1)

    searchNumberInternal list 0