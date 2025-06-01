module PointFree.Tests

open NUnit.Framework
open FsCheck
open PointFree

let testCases = 
    [
        (3, [1; 2; -3; 4; 0], [3; 6; -9; 12; 0]);
        (-3, [1; 2; -3; -4; 0], [-3; -6; 9; 12; 0]);
        (0, [1; 2; 3; 4; 5], [0; 0; 0; 0; 0]);
        (123, [0; 0; 0; 0; 0], [0; 0; 0; 0; 0]);
        (123, [], [])
    ] |> List.map TestCaseData

[<TestCaseSource(nameof(testCases))>]
let ``Transformed function should work correctly`` n list expected =
    Assert.That(func'3 n list = expected)

[<Test>]
let ``Transformed function should be equivalent to original one`` () =
    let areFunctionsEquivalent n (list: List<int>) = func n list = func'3 n list

    Check.QuickThrowOnFailure areFunctionsEquivalent
