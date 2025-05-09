module EvenNumbers.Tests

open NUnit.Framework
open FsCheck
open EvenNumbers.EvenNumbersCounters

let testData = 
    [
        ([1..5], 2);
        ([0; 0; 1; 2], 3);
        ([], 0);
        ([1; 3; 5], 0);
        ([-4..4], 5)
        ([-1; 1], 0)
    ] |> List.map(fun (list, expected) -> TestCaseData(list, expected))


[<TestCaseSource("testData")>]
let ``Counter via map should return expected number of even numbers`` list expected =
    Assert.That(countViaMap list = expected)

[<Test>]
let ``Counters via map and filter should be equivalent`` () =
    let areCountersViaMapAndFilterEquivalent (list: List<int> ) = countViaMap list = countViaFilter list

    Check.QuickThrowOnFailure areCountersViaMapAndFilterEquivalent

[<Test>]
let ``Counters via filter and fold should be equivalent`` () =
    let areCountersViaFoldAndFilterEquivalent (list: List<int> ) = countViaFilter list = countViaFold list

    Check.QuickThrowOnFailure areCountersViaFoldAndFilterEquivalent