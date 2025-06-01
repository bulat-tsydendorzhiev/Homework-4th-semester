module MapForTrees.Tests

open NUnit.Framework
open MapForTrees

[<Test>]
let ``Map for empty tree should return empty tree``() = 
    let tree = Leaf
    Assert.That(map (fun x -> x + 1) tree = Leaf)

[<Test>]
let ``Map for tree with one node should return tree with mapped node``() = 
    let tree = Node(1, Leaf, Leaf)
    Assert.That(map (fun x -> x + 1) tree = Node(2, Leaf, Leaf))

[<Test>]
let ``Map for nested tree should return expected tree``() = 
    let tree = Node(1, Node(2, Leaf, Leaf), Node(3, Leaf, Leaf))
    let f = (fun (x: int) -> x.ToString())
    let expected = Node("1", Node("2", Leaf, Leaf), Node("3", Leaf, Leaf))

    Assert.That(map f tree = expected)