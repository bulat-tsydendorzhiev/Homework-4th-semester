module ParseTree.Tests

open NUnit.Framework
open ParseTree

[<Test>]
let ``Simple expression should return expected value`` () =
    let tree = Operator (Addition, Operand 3, Operand 4)
    Assert.That(calculate tree = Some(7))

[<Test>]
let ``Nested expression should return expected value`` () =
    let tree = Operator (Multiplication, Operator (Addition, Operand 3, Operand 4), Operand 2)
    Assert.That(calculate tree = Some(14))

[<Test>]
let ``Expression without division by zero should return expected value`` () =
    let tree = Operator (Division, Operand 10, Operand 2)
    Assert.That(calculate tree = Some(5))

[<Test>]
let ``Expression with division by zero should return None`` () =
    let tree = Operator (Addition, Operator (Division, Operand 10, Operand 0), Operand 5)
    Assert.That(calculate tree = None)