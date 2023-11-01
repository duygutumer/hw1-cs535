using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;

        Socket clientSocket;

        public Form1()
        {
            InitializeComponent();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox2.Text;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            int portNum;
            if (Int32.TryParse(textBox3.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    textBox4.AppendText("Connected to the server!\n");
                    connected = true;
                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch
                {
                    textBox4.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                textBox4.AppendText("Check the port\n");
            }
        }
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    textBox4.AppendText("Server: " + incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        textBox4.AppendText("The server has disconnected\n");
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;

            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }
    }
}
