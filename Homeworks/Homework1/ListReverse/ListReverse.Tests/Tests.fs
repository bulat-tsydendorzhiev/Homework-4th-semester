module ListReverse.Tests

open NUnit.Framework
open ListReverse

let testData =
    [
        ([1; 2; 3], [3; 2; 1]);
        ([123], [123]);
        ([], [])
    ] |> List.map (fun (list, reversed) -> TestCaseData(list, reversed))

[<TestCaseSource("testData")>]
let ``List after reverse should be reverse`` list reversed =
    Assert.That(reverseList list = reversed)