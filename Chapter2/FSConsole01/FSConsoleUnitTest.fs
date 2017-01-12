namespace FSConsole01
    open Microsoft.VisualStudio.TestTools.UnitTesting
    open FsUnit.MsTest

    module MathFunc =
            let rec fact x = 
                match x with
                | 1 -> 1
                | a when a < 1 -> 1
                | _ -> x * fact (x-1) 

    module FSConsoleUnitTest =

        [<TestClass>]
        type FactTest() =
            class
                [<TestMethod>]
                member this.FactTest01() =
                    MathFunc.fact 3 |> should equal 6
            end

