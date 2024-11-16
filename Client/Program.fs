namespace PoroChat.Client

open Avalonia
open Avalonia.FuncUI.Hosts


module Program =
    [<EntryPoint>]
    let main argv =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(argv)