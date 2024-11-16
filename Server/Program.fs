open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open PoroChat.Server

let builder = WebApplication.CreateBuilder()
builder.Services.AddSignalR() |> ignore

let app = builder.Build()

app.MapHub<ChatHub>("/chathub")
app.Run()