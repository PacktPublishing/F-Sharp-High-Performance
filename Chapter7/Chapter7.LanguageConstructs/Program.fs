// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
//    PatternMatching.SimpleGradePattern "B" |> ignore
//    Console.WriteLine("Pattern Matching test")
//    PatternMatching.GradeBenchmarkSamplingTest 30
    Console.WriteLine(ActivePatterns.TestEvenNumber 5)
    Console.WriteLine(ActivePatterns.TestEvenNumber 6)
    0 // return an integer exit code
