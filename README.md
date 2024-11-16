# PoroChat

A real-time chat application built with F# and SignalR, demonstrating modern .NET development practices and real-time communication capabilities.

## 🌟 Features

- Real-time messaging using SignalR
- Cross-platform desktop client built with Avalonia UI
- Clean architecture with separate client and server projects
- Modern F# functional programming patterns
- Fluent design system integration

## 🛠 Technology Stack

- **Backend:**
  - F# (.NET 8.0)
  - SignalR for real-time communication
  - ASP.NET Core

- **Frontend:**
  - F# (.NET 8.0)
  - Avalonia UI
  - Avalonia.FuncUI for functional UI development
  - SignalR.Client

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- An IDE (Visual Studio, Rider, or VS Code)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/PoroChat.git
cd PoroChat```

2. Build the solution:
```bash
dotnet build
```

3. Start the server:
```bash
cd Server
dotnet run
```

4. In a new terminal, start the client:
```bash
cd Client
dotnet run
```

## 📐 Architecture

The solution consists of two main projects:

### Server
The server project handles real-time message broadcasting using SignalR Hub. Key components:
- ChatHub: Manages real-time message distribution
- Minimal API setup with SignalR configuration

### Client
The client project provides a desktop UI using Avalonia. Key features:
- Real-time message updates
- Clean UI with message history
- Username customization
- Responsive layout

## 💡 Implementation Details

The application demonstrates several important concepts:

1. **Real-time Communication**
   - SignalR hub for message broadcasting
   - Asynchronous message handling

2. **Functional Programming**
   - F# type safety
   - Immutable state management
   - Pattern matching for robust error handling

3. **UI Architecture**
   - MVVM pattern using Avalonia.FuncUI
   - Responsive design
   - Event-driven architecture

## 🔧 Development

To modify the application:

1. Server endpoints can be configured in `Server/Program.fs`
2. Client connection settings are in `Client/Chat.fs`

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## ✨ Acknowledgments

- Avalonia UI for the cross-platform UI framework
- SignalR team for the real-time communication framework
- F# community for excellent documentation and support