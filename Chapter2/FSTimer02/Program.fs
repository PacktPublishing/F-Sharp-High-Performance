open System
let rec fact x = 
    match x with
    | 1 -> 1
    | a when a < 1 -> 1
    | _ -> x * fact (x-1) 

[<EntryPoint>]
let main argv = 
    let stopwatch1 = new System.Diagnostics.Stopwatch()
    stopwatch1.Reset()
    stopwatch1.Start()
    for cnt = 1 to 3000000 do
        fact 5 |> ignore 
    stopwatch1.Stop()
    let timeDuration = stopwatch1.ElapsedMilliseconds
    Console.WriteLine(String.Concat("time elapsed in milliseconds:", timeDuration))
    0 // return an integer exit code
