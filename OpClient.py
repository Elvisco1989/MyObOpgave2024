import socket
import json

Header = 1024
ServerPort = 9090
ServerName = socket.gethostbyname(socket.gethostname())
Address = (ServerName, ServerPort)

Clientsocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
Clientsocket.connect(Address)

def send_command(cmd):
    Clientsocket.send(cmd.encode())
    server_response = Clientsocket.recv(Header).decode('utf-8')
    return server_response

while True:
    user_input = input("Enter Either Random, Add, Subtract: ")
    response = send_command(user_input)
    print(response)  

    if response == "Input numbers":
        
        print("Enter two numbers separated by space:")
        numbers_input = input()
        numbers = numbers_input.split()  
        try:
            if len(numbers) == 2:
            
                response = send_command(" ".join(numbers))  
                print(response)  
            else:
                print("Invalid input. Please enter two numbers separated by space.")
        except Exception as e:
            print(f"Error: {e}")


