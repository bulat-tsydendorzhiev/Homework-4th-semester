module BracketSequence.Tests

open NUnit.Framework
open BracketSequence

let balancedTestCases = 
    [
        "()";
        "";
        "(()){}[]";
        "{[()()]}";
        "((((()))))";
        "{[(a + b) * (c - d)]}";
        "a(b)c{d[e]f}g"
    ] |> List.map TestCaseData

let unbalancedTestCases = 
    [
        "(()";
        "(]";
        "()(()";
        "())";
        "{}]";
        "{[]"
    ] |> List.map TestCaseData

[<TestCaseSource(nameof(balancedTestCases))>]
let ``Balanced test cases should be balanced`` str =
    Assert.That(isBalanced str)

[<TestCaseSource(nameof(unbalancedTestCases))>]
let ``Unbalanced test cases should not be balanced`` str =
    Assert.That(isBalanced str |> not)