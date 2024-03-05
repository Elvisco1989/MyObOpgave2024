import socket
import random
import threading

Header = 1024
ServerPort = 9090
ServerName = socket.gethostbyname(socket.gethostname())
Address = (ServerName, ServerPort)
Format = 'utf-8'
Disconnect_Message = "!Disconnect"

Server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
Server.bind(Address)

Server.listen()
print(f"[LISTENING] Server is listening on {ServerName}")



def handle_client(ClientConn):
    while True: 
        command = ClientConn.recv(Header)
        if not command:
            break
        if command.decode().startswith("Random"):
            ClientConn.send("Input numbers".encode())
            numbers = ClientConn.recv(1024).split()
            if len(numbers)==2:
                num1,num2 = map(int,numbers)
                result = random.randint(num1,num2)
                ClientConn.send(str(result).encode())
        elif command.decode().startswith("Add"):
            ClientConn.send("Input numbers".encode())
            numbers = ClientConn.recv(Header).decode().split()
            if len(numbers) == 2:
                num1, num2 = map(int, numbers)
                result = num1 + num2
                ClientConn.send(str(result).encode())
        elif command.decode().startswith("Subtract"):
            ClientConn.send("Input numbers".encode())
            numbers = ClientConn.recv(Header).decode().split()
            if len(numbers) == 2:
                num1, num2 = map(int, numbers)
                result = num1 - num2
                ClientConn.send(str(result).encode())

# Accept incoming connections and handle clients
while True:
    ClientConn, Address = Server.accept()
    print(f"Connected by {Address}")
    client_handler = threading.Thread(target=handle_client, args=(ClientConn,))
    client_handler.start()

    