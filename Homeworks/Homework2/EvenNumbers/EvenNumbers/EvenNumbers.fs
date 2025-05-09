namespace EvenNumbers

module EvenNumbersCounter =
    let countViaMap list = 
        list |> Seq.map(fun x -> (x + 1) % 2) |> Seq.sum

    let countViaFilter list =
        list |> Seq.filter(fun x -> x % 2 = 0) |> Seq.length

    let countViaFold list =
        list |> Seq.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0
