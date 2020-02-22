using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace QuickOdooCrawler
{
    public class Communication
    {
        private byte[] result = new byte[1024];
        private int myProt = 8032;
        private Socket serverSocket;
        private Action<string, Action<string>> method;
        public Communication(Action<string, Action<string>> Method)
        {
            method = Method;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, myProt));
            serverSocket.Listen(10);
            Thread myThread = new Thread(ListenClientConnect);
            myThread.IsBackground = true;
            myThread.Start();
        }

        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.IsBackground = true;
                receiveThread.Start(clientSocket);
            }
        }

        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    method(
                        Encoding.ASCII.GetString(result, 0, myClientSocket.Receive(result)),
                        new Action<string>((input) =>
                        {
                            myClientSocket.Send(Encoding.ASCII.GetBytes(input));
                        }));
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }
    }
}
