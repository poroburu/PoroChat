open PoroChat.Client

[<EntryPoint>]
let main argv =
    let client = ChatClient("http://localhost:5000/chathub")

    client.OnReceiveMessage(fun user message ->
        printfn "%s: %s" user message)

    client.Start().Wait()

    // Test message
    client.SendMessage("TestUser", "Hello, SignalR!").Wait()

    System.Console.ReadLine() |> ignore

    client.Stop().Wait()
    0