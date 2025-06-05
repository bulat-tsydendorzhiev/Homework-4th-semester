module Rewrite.Tests

open NUnit.Framework
open FsUnit
open Supermap

[<Test>]
let ``supermap should double each element in the list`` () =
    supermap [1.0; 2.0; 3.0] (fun x -> [x; x])
    |> should equal [1.0; 1.0; 2.0; 2.0; 3.0; 3.0;]

[<Test>]
let ``supermap with empty list should return empty list`` () =
    supermap [] (fun x -> [sin x; cos x]) |> should be Empty

[<Test>]
let ``supermap as map should return mapped list`` () =
    supermap [1; 2; 3] (fun x -> [x * 10]) |> should equal [10; 20; 30]

[<Test>]
let ``supermap with varying output lengths`` () =
    supermap [1; 2] (fun x -> if x % 2 = 0 then [x; x * x] else [x]) |> should equal [1; 2; 4]