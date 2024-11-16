namespace PoroChat.Client

open Avalonia
open Avalonia.Controls
open Avalonia.FuncUI
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Hosts
open Avalonia.Layout
open System

type State = {
    messages: (string * string) list
    currentMessage: string
    username: string
}

module Main =
    // Message types to represent different actions
    type Msg =
        | SetUsername of string
        | SetMessage of string
        | SendMessage
        | ReceiveMessage of string * string

    let init = {
        messages = []
        currentMessage = ""
        username = ""
    }

    // Update function to handle state changes
    let update (msg: Msg) (state: State) =
        match msg with
        | SetUsername username ->
            { state with username = username }
        | SetMessage message ->
            { state with currentMessage = message }
        | SendMessage ->
            let newMessages = (state.username, state.currentMessage) :: state.messages
            { state with messages = newMessages; currentMessage = "" }
        | ReceiveMessage (user, message) ->
            { state with messages = (user, message) :: state.messages }

    let view (state: State) dispatch =
        DockPanel.create [
            DockPanel.children [
                ScrollViewer.create [
                    ScrollViewer.dock Dock.Top
                    ScrollViewer.height 500.0
                    ScrollViewer.content (
                        StackPanel.create [
                            StackPanel.children [
                                for (user, msg) in state.messages do
                                    TextBlock.create [
                                        TextBlock.text (sprintf "%s: %s" user msg)
                                        TextBlock.margin (Thickness(5.0))
                                    ]
                            ]
                        ]
                    )
                ]

                StackPanel.create [
                    StackPanel.dock Dock.Bottom
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.spacing 5.0
                    StackPanel.children [
                        TextBox.create [
                            TextBox.watermark "Username"
                            TextBox.text state.username
                            TextBox.onTextChanged (SetUsername >> dispatch)
                        ]

                        DockPanel.create [
                            DockPanel.children [
                                TextBox.create [
                                    TextBox.watermark "Type a message..."
                                    TextBox.text state.currentMessage
                                    TextBox.onTextChanged (SetMessage >> dispatch)
                                    TextBox.dock Dock.Left
                                    TextBox.width 700.0
                                ]

                                Button.create [
                                    Button.content "Send"
                                    Button.onClick (fun _ -> dispatch SendMessage)
                                    Button.dock Dock.Right
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]

type MainWindow() as this =
    inherit HostWindow()

    do
        base.Title <- "PoroChat"
        base.Width <- 800.0
        base.Height <- 600.0

        let component = Component(fun ctx ->
            let state = ctx.useState(Main.init)
            Main.view state.Current (fun msg ->
                let newState = Main.update msg state.Current
                state.Set newState)
        )

        this.Content <- component
