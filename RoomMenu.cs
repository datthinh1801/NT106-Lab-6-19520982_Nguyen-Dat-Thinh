using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class FormRoomMenu : Form
    {
        private TcpClient client;
        private bool active { get; set; }
        private string session { get; set; }
        private string username { get; set; }

        public FormRoomMenu(string session, string usrname)
        {
            InitializeComponent();
            this.session = session;
            this.username = usrname;
            this.active = false;
            this.client = null;
        }

        private void ConnectServer()
        {
            try
            {
                this.client = new TcpClient();
                this.client.Connect(IPAddress.Parse("127.0.0.1"), 9999);
            }
            catch (Exception e)
            {
                this.Close();
            }
        }

        private void CloseConnection()
        {
            if (this.client != null)
            {
                this.client.Close();
                this.client = null;
            }
        }
        
        private void Write(string data)
        {
            NetworkStream netStream = this.client.GetStream();
            byte[] bytes = AES.Encrypt(data);
            netStream.Write(bytes, 0, bytes.Length);
        }

        private string Read()
        {
            try
            {
                NetworkStream netStream = this.client.GetStream();
                netStream.ReadTimeout = 500;
                byte[] bytes = new byte[this.client.ReceiveBufferSize];
                netStream.Read(bytes, 0, bytes.Length);
                string result = AES.Decrypt(bytes);
                return result.Replace("\0", "");
            }
            catch
            {
                return "TIMEOUT";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ConnectServer();
            Write("CREATE\n" + this.session);
            string reply = Read();
            CloseConnection();

            string[] lines = reply.Split('\n');
            if (lines[0] == "OK")
            {
                string room_code = lines[2];
                new ChatRoom(this.session, room_code, this.username).Show();
                this.active = true;
                this.Close();
            }
            else if (lines[0] == "TIMEOUT")
            {
                ConnectServer();
                Write("CREATE TIMEOUT\n" + this.session);
                CloseConnection();
                MessageBox.Show("Connection timeouts. Please try again.");
            }
            else if (lines[0] == "CHATTING")
            {
                string room_code = lines[2];
                new ChatRoom(this.session, room_code, this.username).Show();
                this.active = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid session!");
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            ConnectServer();
            string room_code = tbCode.Text;
            string msg = "JOIN\n" + this.session + '\n' + room_code;
            Write(msg);
            string reply = Read();
            CloseConnection();

            if (reply == "OK")
            {
                new ChatRoom(this.session, room_code, this.username).Show();
                this.active = true;
                this.Close();
            }
            else if (reply == "TIMEOUT")
            {
                MessageBox.Show("Connection timeouts. Please try again.");
            }
            else
            {
                MessageBox.Show("Invalid room code!");
            }
        }

        private void FormRoomMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If this user has not joined a chat room
            // but close the Room Menu windows.
            // This means the user is logging out.
            if (this.active == false)
            {
                ConnectServer();
                Write("LOGOUT\n" + this.session);
                CloseConnection();
            }
        }
    }
}
