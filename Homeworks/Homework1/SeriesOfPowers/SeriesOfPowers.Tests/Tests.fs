module SeriesOfPowers.Tests

open NUnit.Framework
open SeriesOfPowers

let validTestCases = 
    [
        (1, 2, [2; 4; 8]);
        (2, 1, [4; 8]);
        (1, 1, [2; 4])
        (0, 0, [1])
        (0, 2, [1; 2; 4])
        (2, 0, [4])
    ] |> List.map(fun (n, m, expected) -> TestCaseData(n, m, expected))

let invalidTestCases = 
    [
        (-1, -0);
        (0, -1);
        (-1, -1);
    ] |> List.map(fun (n, m) -> TestCaseData(n, m))

[<TestCaseSource("validTestCases")>]
let ``Series of powers should be expected with valid n and m`` n m expected =
    Assert.That(seriesOfPowers n m = Some(expected))

[<TestCaseSource("invalidTestCases")>]
let ``Series of powers should be None with invalid n and m`` n m =
    Assert.That(seriesOfPowers n m = None)