module PatternMatching
open System
open System.Diagnostics

let SimpleGradePattern grade =
    match grade with
    | "A" -> "Excellent"
    | "B" -> "Very good"
    | "C" -> "Good"
    | "D" -> "Bad"
    | "E" -> "Very Bad"
    | _ -> "undefined"

let SimpleGradeNoPattern (grade:String) =
    if grade.Equals("A") then "Excellent"
    elif grade.Equals("B") then "Very Good"
    elif grade.Equals("C") then "Good"
    elif grade.Equals("D") then "Bad"
    elif grade.Equals("E") then "Very Bad"
    else "undefined"

let GradeBenchmarkTest() =
    let mutable swtimer = new Stopwatch()
    swtimer.Reset() 
    swtimer.Start()
    for i = 1 to 5000000 do
        SimpleGradePattern "B" |> ignore
    swtimer.Stop()
    let timerSimpleGradePattern = swtimer.Elapsed
    swtimer.Reset()
    swtimer.Start()
    for i = 1 to 5000000 do
        SimpleGradeNoPattern "B" |> ignore
    swtimer.Stop()
    let timerSimpleGradeNoPattern = swtimer.Elapsed
    //Console.WriteLine("Elapsed SimpleGradePattern \"B\" =" + timerSimpleGradePattern.Milliseconds.ToString()+" ms") |> ignore
    //Console.WriteLine("Elapsed SimpleGradeNoPattern \"B\" =" + timerSimpleGradeNoPattern.Milliseconds.ToString()+" ms") |> ignore
    new Tuple<Int32,Int32>(timerSimpleGradePattern.Milliseconds,timerSimpleGradeNoPattern.Milliseconds)

let GradeBenchmarkSamplingTest (freq:Int32) : unit =
    let mutable TotalPatternMatch : Int32 = 0
    let mutable TotalNoPatternMatch : Int32 = 0
    for i = 1 to freq do
        //Console.WriteLine("Sampling "+i.ToString()+" of "+freq.ToString())
        let result = GradeBenchmarkTest()
        TotalPatternMatch <- TotalPatternMatch + result.Item1
        TotalNoPatternMatch <- TotalNoPatternMatch + result.Item2
    let AveragePatternMatch = TotalPatternMatch / freq
    let AverageNoPatternMatch = TotalNoPatternMatch / freq
    Console.WriteLine("Average Pattern match result for "+freq.ToString()+" times = "+AveragePatternMatch.ToString()+"ms")
    Console.WriteLine("Average No Pattern match result for "+freq.ToString()+" times = "+AverageNoPatternMatch.ToString()+"ms")
    ()
        