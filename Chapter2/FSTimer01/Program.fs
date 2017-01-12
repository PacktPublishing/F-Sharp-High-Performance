open System
let rec fact x = 
    match x with
    | 1 -> 1
    | a when a < 1 -> 1
    | _ -> x * fact (x-1) 

[<EntryPoint>]
let main argv = 
    let timer1 = new System.Timers.Timer(1.0)
    let mutable timeElapsed = 0
    timer1.Enabled <- true
    timer1.AutoReset <- true
    timer1.Elapsed.Add (fun _ -> timeElapsed <- timeElapsed + 1)
    timer1.Start()
    for cnt = 1 to 3000000 do
        fact 5 |> ignore 
    timer1.Stop()
    Console.WriteLine(String.Concat("time elapsed for ", timeElapsed))
    0 // return an integer exit code
