module BlockingQueueTask

open System
open System.Threading

/// Represents blocking queue.
type BlockingQueue<'T>() =
    let queue = System.Collections.Generic.Queue<'T>()
    let lockObj = obj()

    /// Inserts value into the queue.
    member this.Enqueue(item: 'T) =
        Monitor.Enter(lockObj)
        try
            queue.Enqueue(item)
            Monitor.Pulse(lockObj)
        finally
            Monitor.Exit(lockObj)

    /// Extract value from the queue.
    /// Thread blocks until a value appears in the queue.
    member this.TryDequeue() : 'T =
        Monitor.Enter(lockObj)
        try
            while queue.Count = 0 do
                Monitor.Wait(lockObj) |> ignore

            queue.Dequeue()
        finally
            Monitor.Exit(lockObj)
