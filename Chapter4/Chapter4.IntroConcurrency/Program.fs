// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Data
open System.Data.SqlClient
open System.Threading
open System.Threading.Tasks

let UseBangSample (dbconstring: string) =
    async {
        use dbCon = new SqlConnection(dbconstring)
        use sqlCommand = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES")
        use! dataReader = Async.AwaitTask(sqlCommand.ExecuteReaderAsync(CommandBehavior.Default))
        printfn "Finished querying"        
    }

let UseBangCancellationSample (dbconstring: string, tokenSource:CancellationTokenSource) =
    async {
        use dbCon = new SqlConnection(dbconstring)
        use sqlCommand = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES")
        use! dataReader = Async.AwaitTask(sqlCommand.ExecuteReaderAsync(CommandBehavior.Default, tokenSource.Token))
        printfn "Finished querying"        
    }

let bufferData = Array.zeroCreate<byte> 100000000

let async1 =
     async {
       use outputFile = System.IO.File.Create("longoutput.dat")
       do! outputFile.AsyncWrite(bufferData) 
     }

open System.Windows.Forms

[<EntryPoint>]
[<STAThread>]
let main argv = 
    let form = new Form(Text = "Test Form")
    let button = new Button(Text = "Start")
    form.Controls.Add(button)
    button.Click.Add(fun args -> let task = Async.StartAsTask(async1)
                                 printfn "Do some other work..."
                                 task.Wait()
                                 printfn "done")
    form.Show()
    Application.Run(form)
    printfn "%A" argv
    0 // return an integer exit code
