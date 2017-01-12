module ParallelInvokeSample01

open System
open System.Diagnostics
open System.Threading.Tasks

let rec fact x = 
    match x with
    | n when n < 2 -> 1
    | _ -> fact(x-1) * x
    
let factwrap x =
    let factresult = fact x
    ignore


let runningProcesses = fun () -> 
    let processes = Process.GetProcesses()
    let processNames = 
        processes
        |> Seq.map (fun p -> p.ProcessName)
    for name in processNames do
        Console.WriteLine(name)
        
