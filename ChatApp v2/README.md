# Chat Application v2 with TCP/IP sockets

Chat Application v2 is a continuation of my initial 'Chat App' project and is a simple chat program developed in C# using Windows Forms, that is based on a client-server architecture using TCP/IP sockets. It allows communication between multiple instances of the program, with one acting as the server and others as clients.

## Demo

![Demo ChatApp v2](Demo%20ChatApp%20v2.gif)


## How to Use

1. **Build/Compile the Project:**
   - Open the `Server` project in your preferred C# development environment.
   - Build/Compile the project to generate the server executable.

2. **Run the Server:**
   - Navigate to the `bin/Debug` directory in the `Server` project folder.
   - Run the executable (`Server.exe`) to start the server.
   - Input the desired Port (e.g., 80) in the textbox.
   - Click the "Start" button to initiate the server.
   - The program will wait for incoming connections.

3. **Run a Client:**
   - Open the `Client` project in a separate instance of your preferred C# development environment.
   - Build/Compile the project to generate the client executable.
   - Navigate to the `bin/Debug` directory in the `Client` project folder or on a different machine.
   - Run the executable (`Client.exe`).
   - Input the IP address and Port of the server in the respective textboxes.
   - Click the "Connect" button to establish a connection with the server.

4. **Chatting:**
   - Once connected, clients can send messages to each other through the server.
   - Type your message in the lower text area and click the "Send" button.
   - The chat history will be displayed in the upper text area.

5. **Closing the Application:**
   - To close the server or client applications, use the standard window close button (X) or any other preferred method.


## Server-Specific Information:

- **Client Username and Message Broadcasting**:
  - The server extracts the port number of connected clients and uses it as a unique username.
  - When a client sends a message, the server broadcasts it to all connected clients in the format: `<username>: <message>`.
    - For example, if a client with IP 192.168.1.100 and port 63845 sends "Hello," the broadcasted message would be: `63845: Hello`.
    - This allows clients to see who sent each message in the chat.

- **Notification on Client Join and Leave**:
  - When a new client joins, the server notifies all connected clients in the chat screen, displaying the new client's username and the message: `Client <username> joined.`
  - When a client disconnects, the server notifies all connected clients in the chat screen, displaying the disconnected client's username and the message: `Client <username> left.`


## Key Components:

- **TcpListener and TcpClient**:
  - TcpListener is used to listen for incoming connections on the server side.
  - TcpClient is used to initiate a connection to the server on the client side.

- **StreamReader and StreamWriter**:
  - StreamReader (STR) and StreamWriter (STW) are used for reading from and writing to the network stream, enabling bidirectional communication.

- **Background Workers**:
  - Background workers (backgroundWorker1 and backgroundWorker2) ensure that communication operations do not freeze the UI, running them on separate threads.


## Troubleshooting

- If the program freezes during server startup, ensure that the specified port is available and not blocked by other applications.
- If connection issues arise during client connection, double-check the IP address and port of the server.

## Dependencies

- .NET Framework v4.8

## Author

Grrr1337 aka. Vladimir Balabanov
