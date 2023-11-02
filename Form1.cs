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
        private readonly TamperProofProcessor _tamperProofProcessor;
        bool terminating = false;
        bool connected = false;
        private byte[] _aesKey;
        private Encryptor _encryptor;
        Socket clientSocket;

        public Form1()
        {
            InitializeComponent();
            _tamperProofProcessor = new TamperProofProcessor();
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            _encryptor = new Encryptor();
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
                    Byte[] buffer = new Byte[128];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if(incomingMessage == "Rekey")
                    {
                        _aesKey = _tamperProofProcessor.GetNewSessionKey();
                        string newKey = Convert.ToBase64String(_aesKey);
                        textBox4.AppendText("Get new session key after server's request: " + newKey + "\n");
                        
                    }
                    else
                    {
                        string message = _encryptor.Decrypt(Encoding.Default.GetBytes(incomingMessage), _aesKey);
                        textBox4.AppendText("Server: " + message + "\n");
                    }
                    
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
            //send message
            string message = textBox1.Text;

            if (message != "" && message.Length <= 128)
            {
                (byte[]IV, byte[]ctext) = _encryptor.Encrypt(_aesKey, message);
                Byte[] combined = new byte[IV.Length + ctext.Length];

                Array.Copy(IV, combined, IV.Length);
                Array.Copy(ctext, 0, combined, IV.Length, ctext.Length);

                clientSocket.Send(combined);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rekey
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            string newKey = Convert.ToBase64String(_aesKey);
            textBox4.AppendText("New key is: " + newKey);

            string message = "Rekey";

            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);

                clientSocket.Send(buffer);
            }
        }
    }
}
