module NumberSearch.Tests

open NUnit.Framework
open NumberSearch

let notContainedNumberTestCases = 
    [
        ([1; 2; 3], 4);
        ([], 1);
        ([1], 2);
    ] |> List.map(fun (list, notContainedNumber) -> TestCaseData(list, notContainedNumber))

let containedNumberTestCases = 
    [
        ([1; 2; 3], 1, 0);
        ([4; 5; 6], 6, 2);
        ([1], 1, 0);
    ] |> List.map(fun (list, containedNumber, position) -> TestCaseData(list, containedNumber, position))

[<TestCaseSource("notContainedNumberTestCases")>]
let ``Search should return None with not contained number`` list notContainedNumber =
    Assert.That(searchNumber list notContainedNumber = None)

[<TestCaseSource("containedNumberTestCases")>]
let ``Search should return correct position of contained number`` list containedNumber position =
    Assert.That(searchNumber list containedNumber = Some(position))
