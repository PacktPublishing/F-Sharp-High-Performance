open System
open Microsoft.FSharp.Control

type EmailMessage() =
    member val From : String = "" with get, set
    member val To : String = "" with get, set
    member val Cc : String = "" with get, set
    member val DateSent : DateTime = (DateTime.Now) with get
    member val Subject : String = "" with get, set
    member val Content : String = "" with get, set

let mailbox = new MailboxProcessor<EmailMessage>(fun mailprocess ->
    let rec loop =
        async { printfn "Incoming message!" 
                let! msg = mailprocess.Receive()
                printfn "Message received. \r\nFrom: %s, \r\nDate received: %s" msg.From (msg.DateSent.ToString())
                printfn "Subject: %s" msg.Subject
                printfn "Content: \r\n %s" msg.Content
                return! loop }
    loop)

let email1 = new EmailMessage ( From = "john@somemail.com", To = "clark@somemail.com", Subject = "Introduction", Content = "Hello there!")
let email2 = new EmailMessage ( From = "janet@somemail.com", To = "abby@somemail.com", Subject = "Friendly reminder", Content = "Please send me the report today. Thanks!\r\nRegards,\r\nJanet")
mailbox.Start()
mailbox.Post(email1)
mailbox.Post(email2)
Console.WriteLine("Press any key...")
Console.ReadLine() |> ignore