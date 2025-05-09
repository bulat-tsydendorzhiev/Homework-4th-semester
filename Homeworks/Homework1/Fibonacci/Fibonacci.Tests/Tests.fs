module Fibonacci.Tests

open NUnit.Framework
open Fibonacci

[<Test>]
let ``N-th Fibonacci number should be None with invalid N`` () =
    Assert.That(fibonacci -1 = None)

[<TestCase(0, 0)>]
[<TestCase(1, 1)>]
[<TestCase(2, 1)>]
[<TestCase(3, 2)>]
let ``N-th Fibonacci number should be expected with valid N`` n expected =
    Assert.That(fibonacci n = Some(expected))