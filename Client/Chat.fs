namespace PoroChat.Client

open Microsoft.AspNetCore.SignalR.Client

type ChatClient(url: string) =
    let connection =
        HubConnectionBuilder()
            .WithUrl(url)
            .Build()

    member _.Start() =
        connection.StartAsync()

    member _.Stop() =
        connection.StopAsync()

    member _.SendMessage(user: string, message: string) =
        connection.InvokeAsync("SendMessage", user, message)

    member _.OnReceiveMessage(handler: string -> string -> unit) =
        connection.On<string, string>("ReceiveMessage", handler)