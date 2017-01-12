module MailboxSample

open System
open FSharp.Control

type EmailMessage() =
    member val From : String = "" with get, set
    member val To : String = "" with get, set
    member val Cc : String = "" with get, set
    member val DateSent : DateTime = (DateTime.Now) with get
    member val Subject : String = "" with get, set
    member val Content : String = "" with get, set

type ComplexMessage =
    | OrdinaryMessage of EmailMessage
    | ForceReplyDelay of AsyncReplyChannel<DateTime>

let msgManager = new MailboxProcessor<ComplexMessage>(fun inbox ->
    let rec loop msgReceived =
        async { let! msg = inbox.Receive()
                match msg with
                | OrdinaryMessage omsg -> 
                    printfn "Message received. \r\nFrom: %s, \r\nDate received: %s" omsg.From (msg.DateSent.ToString())
                    printfn "Subject: %s" omsg.Subject
                    printfn "Content: \r\n %s" omsg.Content
                    return ()
                | ForceReplyDelay replyChannel ->
                    replyChannel.Reply(msgReceived)
                return! loop DateTime.Now
             }
    loop DateTime.Now
    )

let email1 = new EmailMessage ( From = "john@somemail.com", To = "clark@somemail.com", Subject = "Introduction", Content = "Hello there!")
msgManager.Start()
msgManager.Post(OrdinaryMessage email1)
msgManager.PostAndReply((fun reply -> ForceReplyDelay(reply)), 100) |> ignore


