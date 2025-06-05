module RhombTests

open NUnit.Framework
open FsUnit
open Rhomb

[<Test>]
let ``Rhomb with n=1 should be single asterisk`` () =
    createRhombLines 1
    |> should equal ["*"]

[<Test>]
let ``Rhomb with n=4 should match exact pattern of asterisks`` () =
    createRhombLines 4
    |> should equal [
        "   *   "
        "  ***  "
        " ***** "
        "*******"
        " ***** "
        "  ***  "
        "   *   "
    ]

[<Test>]
let ``Rhomb with n=0 should be empty`` () =
    createRhombLines 0
    |> should be Empty

[<Test>]
let ``Rhomb with negative n should be empty`` () =
    createRhombLines -3
    |> should be Empty