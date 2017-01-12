// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Text
open System.Threading.Tasks

type Person() =
    member val Name: String = "" with get, set
    member val Address: String = "" with get, set
    member val IsMarried = false with get, set
    override this.ToString() = 
        let mutable sb = new StringBuilder()
        sb <- sb.Append("Person{").Append(this.Name).Append("|").Append(this.Address).Append("|")
        sb <- sb.Append(this.IsMarried).Append("}")
        sb.ToString()
    static member Deserialize (serializedString:String) =
        let mutable deserializedPerson = new Person()
        let mutable strippedString = serializedString.Substring(7)
        strippedString <- strippedString.Substring(0,strippedString.Length-1)
        let splitString = strippedString.Split([| "|" |], StringSplitOptions.None)
        deserializedPerson.Name <- splitString.[0]
        deserializedPerson.Address <- splitString.[1]
        deserializedPerson.IsMarried <- Boolean.Parse(splitString.[2])
        deserializedPerson

[<EntryPoint>]
let main argv = 
    let anyPerson1 = new Person(Name = "John Doe", Address="Baker Street", IsMarried = false)
    let anyPerson2 = new Person(Name="Jane Doe", Address ="Arlington Street", IsMarried = true)
    Console.WriteLine(anyPerson1.ToString()) 
    Console.WriteLine(anyPerson2.ToString())
    let anyperson3 = Person.Deserialize(anyPerson1.ToString())
    Console.WriteLine(anyperson3.ToString())
//    Parallel.Invoke(new Action(ParallelInvokeSample01.factwrap 5), new Action(ParallelInvokeSample01.runningProcesses))
//    Parallel.Invoke(new ParallelOptions(MaxDegreeOfParallelism = 5),new Action(ParallelInvokeSample01.factwrap 5), new Action(ParallelInvokeSample01.runningProcesses))\
    //printfn "%A" argv
    0 // return an integer exit code
