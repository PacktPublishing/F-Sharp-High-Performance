// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    TailcallSample.factorial 5 |> ignore
    TailcallSample.accFactorial 5 |> ignore
    0 // return an integer exit code
