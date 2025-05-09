module Factorial.Tests

open NUnit.Framework
open Factorial

[<Test>]
let ``Factorial from negative number should be None`` () =
    Assert.That(factorial -1 = None)

[<TestCase(0, 1)>]
[<TestCase(1, 1)>]
[<TestCase(2, 2)>]
[<TestCase(6, 720)>]
let ``Factorial from natural number should be expected`` number expected=
    Assert.That(factorial number = Some(expected))