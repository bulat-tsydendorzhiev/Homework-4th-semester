namespace EvenNumbers

module EvenNumbersCounters =
    let countViaMap list = 
        list |> List.map(fun x -> abs (x + 1) % 2) |> List.sum

    let countViaFilter list =
        list |> List.filter(fun x -> x % 2 = 0) |> List.length

    let countViaFold list =
        list |> List.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0
