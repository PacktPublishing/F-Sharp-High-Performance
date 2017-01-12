open System
open System.Linq
open System.Threading
open System.Threading.Tasks

let function1() =
  for i = 1 to 10 do
    Console.WriteLine("current datetime is" + DateTime.Now.ToString())
  printfn ""

Parallel.For(1,10, fun(iteration) ->
    Console.WriteLine("Iteration: " + iteration.ToString() + " current datetime: " + DateTime.Now.ToString())
    printfn ""
    )

let seq1 = seq { for i in 1 .. 10 -> (i, i*i) }
for (a, asqr) in seq1 do
  printfn "%d squared is %d" a asqr

Parallel.ForEach(seq1, fun((a,asqr)) ->
  printfn "%d squared is %d" a asqr
    )

