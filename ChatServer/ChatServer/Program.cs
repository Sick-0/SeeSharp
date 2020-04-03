using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;

namespace ChatServer
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();  // all the connected clients

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888); // DA SERVER, listen port 8888
            TcpClient clientSocket = default(TcpClient); // generic client for later use
            int counter = 0; // counting da clients

            serverSocket.Start(); // server start lsitening 

            Console.WriteLine ("Chat Server Started ....");

            counter = 0;
            while ((true)) // infini loop
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();  // we accept tcp client
                byte[] bytesFrom = new byte[10025];  // space for data
                string dataFromClient = null;
                NetworkStream networkStream = clientSocket.GetStream(); // i want your data
                networkStream.Read(bytesFrom, 0, bytesFrom.Length); // actually read da data
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom); // make readable
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$")); // we use dollar sign to get only relevant text
                
                clientsList.Add(dataFromClient, clientSocket);  // adding client to collection
                
                Broadcast(dataFromClient + " Joined ", dataFromClient, false); // send data to everyone (clients)

                Console.WriteLine(dataFromClient + " Joined chat room "); // server message
                HandleClient client = new HandleClient(); // handle the clientr :p 
                client.StartClient(clientSocket, dataFromClient, clientsList); // start the client

            }
        }

        public static  void Broadcast(string msg, string uName, bool flag) // message // username //fis it a person?
        {
            foreach (DictionaryEntry Item in clientsList) 
            {
                TcpClient broadcastSocket; // tempclient
                broadcastSocket = (TcpClient)Item.Value; //broadcasting socket (port wed will use)
                NetworkStream broadcastStream = broadcastSocket.GetStream(); // flow of water and data we need to hook up
                Byte[] broadcastBytes = null;
                
                if (flag == true) 
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg); //markup 
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg); // for nicer dicer
                }
                
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);  // wrrite to stream
                broadcastStream.Flush(); // the actual send
            }
        }
    }
    public class HandleClient
    {
        Hashtable clientsList; 
        TcpClient clientSocket; 
        string clNo; 
        
        public void StartClient(TcpClient inClientSocket, string clineNo, Hashtable cList) 
        {
            this.clientSocket = inClientSocket; 
            this.clNo = clineNo; 
            this.clientsList = cList; 
            Thread ctThread = new Thread(DoChat); // set up the multi thread
            ctThread.Start(); // and start it
        }
        private void DoChat()
        {
            int requestCount = 0; 
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;
            
            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$")); 
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient); 
                    rCount = Convert.ToString(requestCount);

                    Program.Broadcast (dataFromClient, clNo, true); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        } 
    } 

}