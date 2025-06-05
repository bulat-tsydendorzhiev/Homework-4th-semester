module StringCalculations.Tests

open NUnit.Framework
open FsUnit
open StringCalculations

[<Test>]
let ``calculate stop and return None with invalid integer`` () =
    let result = calculate {
        let! a = "5"
        let! b = "minus seven"
        return a + b
    }

    result |> should equal None

[<Test>]
let ``calculate should work with valid integers`` () =
    let result = calculate {
        let! a = "5"
        let! b = "-7"
        return a + b
    }

    result |> should equal (Some -2)