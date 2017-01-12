// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    //SampleFSharpData.displayAllCustomerName() 
    //Console.WriteLine("next sample:")
    Console.WriteLine("Display customer name that starts with Maria")
    SampleFSharpData.displayCustomerNameStartsWith "Maria"
    0 // return an integer exit code
