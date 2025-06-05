module RoundingWorkflow

open System

type RoundingWorkflowBuilder (decimal : int) =
    member _.Bind(value: float, func: float -> float) =
        Math.Round (value, decimal) |> func

    member _.Return(value) = value