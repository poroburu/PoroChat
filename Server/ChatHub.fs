namespace PoroChat.Server

open Microsoft.AspNetCore.SignalR

type ChatHub() =
    inherit Hub()

    member this.SendMessage(user: string, message: string) =
        task {
            do! this.Clients.All.SendAsync("ReceiveMessage", user, message)
        }