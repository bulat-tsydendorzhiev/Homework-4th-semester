module PrimeNumbers.Tests

open NUnit.Framework
open FsUnit
open PrimeNumbers

let testData = 
    [
        (1, seq{2});
        (5, seq{2; 3; 5; 7; 11});
        (10, seq{2; 3; 5; 7; 11; 13; 17; 19; 23; 29});
    ] |> List.map (fun (n, expected) -> TestCaseData(n, expected))

[<TestCaseSource("testData")>]
let ``apt`` n expected =
    generatePrimeNumbers |> Seq.take n |> should equal expected