module RoundingWorkflow.Tests

open NUnit.Framework
open FsUnit
open RoundingWorkflow

[<Test>]
let ``Result should be rounded`` () =
    let result = rounding 3 {
        return 0.167 / 3.5
    }

    result |> should equal 0.048

[<Test>]
let ``Rounding with a zero decimal`` () =
    let result = rounding 0 {
        let! a = 160.123 / 4.123
        let! b = 3.5
        return a / b
    }

    result |> should equal 10.0

[<Test>]
let ``Rounding negative numbers`` () =
    let result = rounding 3 {
        let! a = -125.2 / 7.1
        return a
    }

    result |> should equal -17.634

[<Test>]
let ``Rounding with complex calculation`` () =
    let result = rounding 4 {
        let! r = 1.2345
        let! pi = System.Math.PI

        let! s = pi * r * r

        return s
    }

    result |> should equal 4.7878
