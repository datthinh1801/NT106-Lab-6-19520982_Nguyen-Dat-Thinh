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
using System.Threading;
using System.Security.Cryptography;
using System.IO;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class ChatRoom : Form
    {
        private TcpClient client;
        private bool new_msg;
        private string msg;
        private string session { set; get; }
        private string room_code { set; get; }
        private string content { set; get; }
        private string username { set; get; }
        public ChatRoom(string session, string code, string usrname)
        {
            InitializeComponent();
            this.session = session;
            this.room_code = code;
            this.username = usrname;
            this.content = "";
            this.client = null;
        }

        private void ConnectServer()
        {
            try
            {
                this.client = new TcpClient();
                this.client.Connect(IPAddress.Parse("127.0.0.1"), 9999);
            }
            catch
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

        private void UpdateMessage()
        {
            ConnectServer();
            string msg = "UPDATE MESSAGE\n" +
                this.session + '\n' +
                this.room_code + '\n' +
                this.content.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length.ToString();

            // send the current state of the inbox of user,
            // so that the server know where we are and update new contents for us.
            Write(msg);
            string reply = Read();
            string[] lines = reply.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            while (lines[0] == "MESSAGE")
            {
                this.content += lines[1] + '\n';
                rtbInbox.Text += lines[1] + '\n';

                Write("MESSAGE OK");
                reply = Read();
                lines = reply.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            }
            CloseConnection();
        }

        private int FindPeer(string username, ref List<string> users)
        {
            for (int i = 0; i < users.Count; ++i)
            {
                if (users[i] == username)
                {
                    return i;
                }
            }
            return -1;
        }

        private void UpdatePeers()
        {
            List<string> active_users = new List<string>();

            // Update active users
            ConnectServer();
            string msg = "UPDATE USERS\n" + this.session + '\n' + this.room_code;
            Write(msg);
            string reply = Read();
            string[] lines = reply.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            while (lines[0] == "ADD USERS")
            {
                active_users.Add(lines[1]);

                Write("ADD USERS OK");
                reply = Read();
                lines = reply.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            }
            CloseConnection();

            int i = 0;
            while (i < listViewPeers.Items.Count)
            {
                // if this peer is still in room
                int user_id = FindPeer(listViewPeers.Items[i].Text, ref active_users);
                if (user_id > -1)
                {
                    ++i;
                    active_users.RemoveAt(user_id);
                }
                else
                {
                    listViewPeers.Items.RemoveAt(i);
                }
            }

            while (active_users.Count > 0)
            {
                listViewPeers.Items.Add(active_users[0]);
                active_users.RemoveAt(0);
            }
        }

        private void MaintainConnection()
        {
            while (true)
            {
                if (this.new_msg == true)
                {
                    try
                    {
                        ConnectServer();
                        Write(msg);
                        string reply = Read();
                        CloseConnection();

                        if (reply == "OK")
                        {
                            this.new_msg = false;
                            rtbTyping.Text = "";
                            lbErrorNotif.Text = "";
                        }
                        else
                        {
                            lbErrorNotif.Text = "Cannot send your message. Please try again.";
                        }
                    }
                    catch
                    {
                        lbErrorNotif.Text = "Cannot send your message. Please wait a second and try again.";
                    }
                }

                try
                {
                    string msg = "UPDATE CONTENTS\n" + this.session + '\n' + this.room_code;
                    ConnectServer();
                    Write(msg);

                    string reply = Read();
                    CloseConnection();

                    if (reply == "OK")
                    {
                        UpdateMessage();
                        UpdatePeers();
                    }
                }
                catch
                {
                    // MessageBox.Show("Exceptiong while updating contents. " + ex.Message);
                }

                Thread.Sleep(200);
            }
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            try
            {
                lbRoomCode.Text = this.room_code;
                lbUsername.Text = this.username;
                rtbInbox.Text = "";
                Thread thr = new Thread(MaintainConnection);
                thr.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception while loading chat room. " + exc.Message);
                this.Close();
            }
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ConnectServer();
                Write("LOGOUT\n" + this.session);
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception while closing chat room. " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.msg = "MESSAGE" + '\n' + this.session + '\n' + this.room_code + '\n' + rtbTyping.Text;
            this.new_msg = true;
        }
    }
}
