module BlockingQueue.Tests

open NUnit.Framework
open System.Threading
open FsUnit
open BlockingQueueTask
open System

[<Test>]
let ``Enqueue and TryDequeue should work correctly`` () =
    let queue = BlockingQueue<int>()

    queue.Enqueue(1)
    queue.Enqueue(2)
    queue.Enqueue(3)

    queue.TryDequeue() |> should equal 1
    queue.TryDequeue() |> should equal 2
    queue.TryDequeue() |> should equal 3

[<Test>]
let ``TryDequeue blocks the thread until Enqueue`` () =
    let queue = BlockingQueue<int>()
    let mutable result = 0
    let start = new ManualResetEventSlim(false)

    let anotherThread = 
        Thread(ThreadStart(fun _ ->
            start.Set()
            result <- queue.TryDequeue()
        ))
    anotherThread.Start()

    start.Wait()
    Thread.Sleep(1000)

    queue.Enqueue(123)
    anotherThread.Join(1000)

    result |> should equal 123
