module RoundingWorkflow

open System

type RoundingWorkflowBuilder (decimal : int) =
    member _.Bind(value: float, func: float -> float) =
        Math.Round (value, decimal) |> func

    member _.Return(value: float) = Math.Round (value, decimal)

let rounding decimal = RoundingWorkflowBuilder (decimal)
