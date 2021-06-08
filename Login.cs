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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class FormLogin : Form
    {
        private TcpClient client;
        private string session;
        private string username;
        private string key { set; get; }
        private string iv { set; get; }

        public FormLogin()
        {
            InitializeComponent();
            this.client = new TcpClient();
            this.session = "";

            // Generate AES parameters
            this.key = "NguyenDatThinh 19520982 ANTN2019";
            this.iv = "19520982ANTN2019";
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

        private void HandleReply(string reply)
        {
            string[] lines = reply.Split('\n');

            // If login successfully and this is the first session of the user,
            // enter the room menu.
            if (lines[0] == "OK")
            {
                this.session = lines[1];
                this.username = tbUsername.Text;
                new FormRoomMenu(this.session, this.username).Show();
                this.Close();
            }
            // If login successfuly and this user has logged in somewhere else,
            // enter that chatting room.
            else if (lines[0] == "CHATTING")
            {
                this.session = lines[1];
                string room_code = lines[2];
                this.username = tbUsername.Text;

                // Open the Chat Room
                new ChatRoom(this.session, room_code, this.username).Show();
                this.Close();
            }
            else if (lines[0] == "TIMEOUT")
            {
                ConnectServer();
                Write("LOGIN TIMEOUT\n" + tbUsername.Text + ';' + tbPassword.Text);
                CloseConnection();
                MessageBox.Show("Connection timeouts. Please try again.");
            }
            else
            {
                lbNotif.Text = "Invalid username or password.";
            }
        }

        private bool ValidateInput()
        {
            // Check if there are empty fields
            if (tbUsername.Text.Length == 0 || tbPassword.Text.Length == 0)
            {
                return false;
            }

            // Check if there are special characters 
            Regex rx = new Regex(@"\W");
            if (rx.Match(tbUsername.Text) != Match.Empty)
            {
                return false;
            }

            return true;
        }
        private byte[] Encrypt(string plaintext)
        {
            byte[] encrypted;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Encoding.UTF8.GetBytes(this.key);
                aesAlg.IV = Encoding.UTF8.GetBytes(this.iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plaintext);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        private string Decrypt(byte[] ciphertext)
        {
            string plaintext;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Encoding.UTF8.GetBytes(this.key);
                aesAlg.IV = Encoding.UTF8.GetBytes(this.iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            int i = 0;
            for (; i < plaintext.Length; ++i)
            {
                if (plaintext[i] == '\0')
                {
                    break;
                }
            }
            plaintext = plaintext.Substring(0, i);

            return plaintext;
        }
        private void Write(string msg)
        {
            NetworkStream netStream = this.client.GetStream();
            // byte[] bytes_to_write = Encoding.UTF8.GetBytes(msg);
            byte[] bytes_to_write = Encrypt(msg);
            netStream.Write(bytes_to_write, 0, bytes_to_write.Length);
        }

        private string Read()
        {
            try
            {
                NetworkStream netStream = this.client.GetStream();
                netStream.ReadTimeout = 500;
                byte[] bytes_to_read = new byte[this.client.ReceiveBufferSize];
                netStream.Read(bytes_to_read, 0, bytes_to_read.Length);
                string result = Decrypt(bytes_to_read);
                return result.Replace("\0", "").Replace("\r\n", "\n");
                // return Encoding.UTF8.GetString(bytes_to_read).Replace("\0", "").Replace("\r\n", "\n");
            }
            catch
            {
                return "TIMEOUT";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                lbNotif.Text = "Invalid username or password.";
            }
            else
            {
                string msg = "LOGIN\n" + tbUsername.Text + ";" + tbPassword.Text;
                try
                {
                    ConnectServer();
                    Write(msg);
                    string reply = Read();
                    CloseConnection();
                    HandleReply(reply);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception in button Login. " + ex.Message);
                }
            }
        }

        private void llbSignupInstead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormSignup().Show();
            this.Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
