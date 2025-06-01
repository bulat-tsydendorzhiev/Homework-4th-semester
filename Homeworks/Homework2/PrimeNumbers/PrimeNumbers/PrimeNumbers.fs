module PrimeNumbers

let isPrime number = 
    Seq.exists (fun d -> number % d = 0) {2..int(sqrt(float(number)))} |> not

let generatePrimeNumbers = 
    Seq.initInfinite(fun x -> x + 2) |> Seq.filter isPrime
