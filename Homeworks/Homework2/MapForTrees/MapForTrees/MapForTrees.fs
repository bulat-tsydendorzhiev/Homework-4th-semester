module MapForTrees

type 'a Tree = 
    | Leaf
    | Node of 'a * 'a Tree * 'a Tree

let rec map f tree = 
    match tree with
    | Leaf -> Leaf
    | Node(value, left, right) -> Node(f value, map f left, map f right)