module StringCalculations

type StringCalculationsBuilder () =
    member _.Bind(str: string, func: int -> option<int>) = 
        match System.Int32.TryParse str with
        | true, int -> int |> func
        | _ -> None

    member _.Return(str: string) = 
        match System.Int32.TryParse str with
        | true, int -> Some int
        | _ -> None

let calculate = StringCalculationsBuilder