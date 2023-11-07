using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace Client
{
    public partial class Form1 : Form
    {
        private readonly TamperProofProcessor _tamperProofProcessor;
        bool terminating = false;
        bool connected = false;
        private byte[] _aesKey;
        private Encryptor _encryptor;
        Socket clientSocket;

        private string GetKeyBase64String()
        {
            return Convert.ToBase64String(_aesKey);
        }

        public Form1()
        {
            InitializeComponent();
            _tamperProofProcessor = new TamperProofProcessor(100);
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            _encryptor = new Encryptor();
            textBox1.Enabled = false;
            button1.Enabled = false;
            textBox4.AppendText("Client initialized with key: " + GetKeyBase64String() + "\n");
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
                    textBox1.Enabled = true;
                    button1.Enabled = true;
                    connect_btn.Enabled = false;
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

        private byte[] RemoveNullBytes(byte[] bytes)
        {
            int idx = bytes.Length - 1;
            while (bytes[idx] == 0)
            {
                --idx;
            }

            byte[] result = new byte[idx + 1];
            Array.Copy(bytes, result, idx + 1);

            return result;
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
                    if (incomingMessage == "Rekey")
                    {
                        _aesKey = _tamperProofProcessor.GetNewSessionKey();
                        textBox4.AppendText("Rekey initiated by Server. New key: " + GetKeyBase64String() + "\n");
                    }
                    else
                    {
                        textBox4.AppendText("Received Message.\n");
                        byte[] encryptedMessageBytes = RemoveNullBytes(buffer);

                        textBox4.AppendText("Nonce: " + Convert.ToBase64String(encryptedMessageBytes.Take(16).ToArray()) + "\n");
                        textBox4.AppendText("Cipher text: " + Convert.ToBase64String(encryptedMessageBytes.Skip(16).ToArray()) + "\n");
                        string message = _encryptor.Decrypt(encryptedMessageBytes, _aesKey);
                        textBox4.AppendText("Decryption key: " + GetKeyBase64String() + "\n");
                        textBox4.AppendText("Plain text: " + message + "\n");

                        Encryptor.IncreaseNonce();
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        textBox4.AppendText("The server has disconnected\n");
                        connect_btn.Enabled = true;
                        button2.Enabled = false;
                        textBox1.Enabled = false;
                        button1.Enabled = false;
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
                textBox4.AppendText("Sending...\n");
                textBox4.AppendText("Plain text: " + message + "\n");

                var encryptedMessage = _encryptor.Encrypt(_aesKey, message);
                textBox4.AppendText("Encryption key: " + GetKeyBase64String() + "\n");
                textBox4.AppendText("Nonce: " + Convert.ToBase64String(encryptedMessage.Take(16).ToArray()) + "\n");
                textBox4.AppendText("Cipher text: " + Convert.ToBase64String(encryptedMessage.Skip(16).ToArray()) + "\n");

                clientSocket.Send(encryptedMessage);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rekey
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            textBox4.AppendText("Rekey Initiated. New key: " + GetKeyBase64String() + "\n");

            string message = "Rekey";
            Byte[] buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
        }
    }
}
