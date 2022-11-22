using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxDuPendu
{
    public partial class serverForm : Form
    {
        private bool waitButton = true;
        public string TextToSend;
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static List<int> _list = new List<int>();
        private const int PORT = 3500;
        public static GameForm gameForm = null;


        public serverForm()
        {
            InitializeComponent();
        }
        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), PORT);
                }
                catch (SocketException)
                {
                    // TO DO: Clear texte console
                }
            }

        }

        private void RequestLoop()
        {

            gameForm = new GameForm(2);
            gameForm.Show();
            gameForm.setSocket(ClientSocket);
            new System.Threading.Thread(ReceiveResponse).Start();
            

        }

        private static void Exit()
        {
            SendString("exit");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private void SendRequest(string texte)
        {
            // Console.Write("Send a request: ");
            string request = texte;
            

            // attends que le backgroundWorker1
            while (waitButton)
            {
                System.Threading.Thread.Sleep(100);
            }
            


            SendString(request);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }


        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void ReceiveResponse()
        {
            while (true)
            {
                
                var buffer = new byte[2048];
                int received = ClientSocket.Receive(buffer, SocketFlags.None);
                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                Console.WriteLine("Text received : " + text);

                

                // if text contains /find 
                if (text.Contains("/find"))
                {
                    // split text
                    string[] words = text.Split(' ');
                    // get the word
                    string word = words[1];
                    // get the player
                    string player = words[2];

                    // send the word to the gameForm
                    gameForm.StartNewGame(word, player);
                }
            }
                
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //IPAddress.Parse(ClientIPtextBox.Text), int.Parse(ClientPorttextBox.Text)
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                _list.Add(rnd.Next(1, 100));
            }

            ConnectToServer();
            RequestLoop();
            //Exit();
        }
    }
}
