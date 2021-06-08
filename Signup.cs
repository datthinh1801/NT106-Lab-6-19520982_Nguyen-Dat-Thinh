using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class FormSignup : Form
    {
        private TcpClient client;
        public FormSignup()
        {
            InitializeComponent();
        }

        private void ConnectServer()
        {
            try
            {
                this.client = new TcpClient();
                this.client.Connect(IPAddress.Parse("127.0.0.1"), 9999);
            }
            catch (Exception ex)
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

        private void ShowCredentialError()
        {
            lbCredentialNotif.Text = "Invalid username or password.";
        }

        private void ShowDupPassError()
        {
            lbDupPassNotif.Text = "Password does not match!";
        }

        private void ResetNotif()
        {
            lbDupPassNotif.Text = "";
            lbCredentialNotif.Text = "";
        }

        private void llbLoginInstead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }

        private bool ValidateInput()
        {
            if (tbUsername.Text.Length == 0 || tbPassword.Text.Length == 0)
            {
                ShowCredentialError();
                return false;
            }
            else if (tbPassword.Text != tbRePassword.Text)
            {
                ShowDupPassError();
                return false;
            }

            Regex rx = new Regex(@"\W");
            if (rx.Match(tbUsername.Text) != Match.Empty)
            {
                ShowCredentialError();
                return false;
            }
            return true;
        }

        private void HandleReply(string reply)
        {
            string[] lines = reply.Split('\n');
            if (lines[0] == "OK")
            {
                new FormLogin().Show();
                this.Close();
            }
            else if (lines[0] == "TIMEOUT")
            {
                MessageBox.Show("Connection timeouts. Please try again.");
            }
            else
            {
                ResetNotif();
                ShowCredentialError();
            }
        }

        private void Write(string data)
        {
            NetworkStream netStream = this.client.GetStream();
            byte[] to_send = AES.Encrypt(data);
            netStream.Write(to_send, 0, to_send.Length);
        }

        private string Read()
        {
            try
            {
                NetworkStream netStream = this.client.GetStream();
                netStream.ReadTimeout = 500;
                byte[] to_read = new byte[this.client.ReceiveBufferSize];
                netStream.Read(to_read, 0, to_read.Length);
                string result = AES.Decrypt(to_read);
                return result.Replace("\0", "\n");
            }
            catch
            {
                return "TIMEOUT";
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            ResetNotif();

            if (ValidateInput() == true)
            {
                string msg = "SIGN UP" + '\n' + tbUsername.Text + ';' + tbPassword.Text;
                ConnectServer();
                Write(msg);
                string reply = Read();
                CloseConnection();
                HandleReply(reply);
            }
        }
    }
}
