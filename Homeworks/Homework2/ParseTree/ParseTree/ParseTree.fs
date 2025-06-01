module ParseTree

type Operation = 
    | Addition 
    | Subtraction
    | Multiplication
    | Division

type ParseTree = 
    | Operand of int
    | Operator of Operation * ParseTree * ParseTree

let calculate tree = 
    let performOperation operation leftOption rightOption =
        match leftOption, rightOption with
        | Some left, Some right ->
            match operation with
            | Addition -> Some(left + right)
            | Subtraction -> Some(left - right)
            | Multiplication -> Some(left * right)
            | Division -> if right <> 0 then Some(left / right) else None
        | _ -> None

    let rec calculateInternal tree = 
        match tree with 
        | Operand value -> Some(value)
        | Operator (operation, left, right) -> performOperation operation (calculateInternal left) (calculateInternal right)

    calculateInternal tree