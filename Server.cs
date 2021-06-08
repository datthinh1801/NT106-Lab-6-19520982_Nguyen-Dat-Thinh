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
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private List<Client> clients;
        private List<Room> rooms;
        private string log;

        public Server()
        {
            InitializeComponent();
            this.log = "";
            this.listener = null;
        }

        private void UpdateLog()
        {
            if (rtbLog.Text != this.log)
            {
                rtbLog.Text = this.log;
            }
            if (lbUserCount.Text != this.clients.Count.ToString())
            {
                lbUserCount.Text = this.clients.Count.ToString();
            }
            if (lbRoomCount.Text != this.rooms.Count.ToString())
            {
                lbRoomCount.Text = this.rooms.Count.ToString();
            }
        }

        // Check if a given credential exists
        private bool CheckCredential(string usrname, string pssw)
        {
            bool status_code = false;
            try
            {
                using (StreamReader sr = new StreamReader("credentials.txt"))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] credential = line.Split(';');
                        if (credential[0] == usrname && credential[1] == pssw)
                        {
                            status_code = true;
                            break;
                        }
                        line = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                return status_code;
            }
            return status_code;
        }

        private bool CheckUsername(string usrname)
        {
            bool status_code = false;
            try
            {
                using (StreamReader sr = new StreamReader("credentials.txt"))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] credential = line.Split(';');
                        if (credential[0] == usrname)
                        {
                            status_code = true;
                            break;
                        }
                        line = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                return status_code;
            }
            return status_code;

        }

        private bool ValidateUsername(string usrname)
        {
            Regex rx = new Regex(@"\W");
            if (rx.Match(usrname) != Match.Empty)
            {
                return false;
            }
            return true;
        }

        private void AddUser(string usrname, string pssw)
        {
            using (StreamWriter sw = new StreamWriter("credentials.txt", true))
            {
                sw.WriteLine(usrname + ";" + pssw);
            }
        }

        private string Read(ref TcpClient client)
        {
            NetworkStream netStream = client.GetStream();
            // netStream.ReadTimeout = 600;

            if (netStream.CanRead)
            {
                byte[] bytes = new byte[client.ReceiveBufferSize];
                netStream.Read(bytes, 0, (int)client.ReceiveBufferSize);
                string result = AES.Decrypt(bytes);
                return result.Replace("\0", "").Replace("\r\n", "\n").Replace("\r", "\n");
                // return Encoding.UTF8.GetString(bytes).Replace("\0", "").Replace("\r\n", "\n").Replace("\r", "\n");
            }
            else
            {
                MessageBox.Show("From server: Cannot read from netStream");
                return "";
            }
        }

        private void Write(ref TcpClient client, string data)
        {
            NetworkStream netStream = client.GetStream();
            if (netStream.CanWrite)
            {
                // byte[] bytes = Encoding.UTF8.GetBytes(data);
                byte[] bytes = AES.Encrypt(data);
                netStream.Write(bytes, 0, bytes.Length);
            }
            else
            {
                MessageBox.Show("From server: Cannot write to netStream");
            }
        }

        private int CheckSession(string session)
        {
            for (int i = 0; i < this.clients.Count; ++i)
            {
                for (int j = 0; j < this.clients[i].sessions.Count; ++j)
                {
                    if (this.clients[i].sessions[j] == session)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int CheckRoomCode(string code)
        {
            for (int i = 0; i < this.rooms.Count; ++i)
            {
                if (this.rooms[i].room_code == code)
                {
                    return i;
                }
            }
            return -1;
        }

        private int CountActiveUserOfRoom(string room_code)
        {
            int count = 0;
            foreach (Client c in this.clients)
            {
                if (c.room_code == room_code)
                {
                    ++count;
                }
            }
            return count;
        }

        private void HandleClient(ref TcpClient client)
        {
            try
            {
                string msg;
                string reply;
                string status;

                // Receive request from a client
                msg = Read(ref client);

                string[] lines = msg.Split('\n');

                // If request is LOGIN
                if (lines[0] == "LOGIN")
                {
                    string[] credential = lines[1].Split(';');

                    // If credential is valid
                    if (CheckCredential(credential[0], credential[1]))
                    {
                        // Randomly generate a unique session key
                        string session = new Random().Next().ToString();
                        while (CheckSession(session) > -1)
                        {
                            session = new Random().Next().ToString();
                        }

                        // If this client has already logged in somewhere else
                        Client matched_client = this.clients.Find(c => c.username == credential[0]);

                        // If yes
                        if (matched_client != null)
                        {
                            // If this client is in a chat room
                            if (matched_client.room_code != "")
                            {
                                status = "CHATTING";
                                reply = status + '\n' + session + '\n' + matched_client.room_code;
                                Write(ref client, reply);
                            }
                            // If this client has logged in somewhere else but not in any chat room
                            else
                            {
                                status = "OK";
                                reply = status + '\n' + session;
                                Write(ref client, reply);
                            }

                            // Add new session code
                            matched_client.sessions.Add(session);
                        }
                        // If this client does not log in anywhere else
                        else
                        {
                            status = "OK";
                            reply = status + '\n' + session;
                            Write(ref client, reply);

                            this.clients.Add(new Client());
                            this.clients[this.clients.Count - 1].username = credential[0];
                            this.clients[this.clients.Count - 1].sessions.Add(session);
                            this.log += "[USER STATUS] " + credential[0] + " has just logged in.\n";
                        }
                    }
                    else
                    {
                        status = "LOGIN ERROR";
                        reply = status;
                        Write(ref client, reply);
                    }
                }
                else if (lines[0] == "SIGN UP")
                {
                    string[] credential = lines[1].Split(";");

                    // check if username is valid
                    if (ValidateUsername(credential[0]))
                    {
                        // Check if username already exists
                        if (CheckUsername(credential[0]))
                        {
                            Write(ref client, "ERROR");
                        }
                        else
                        {
                            Write(ref client, "OK");

                            this.log += "[USER STATUS] " + credential[0] + " has just signed up.\n";
                            AddUser(credential[0], credential[1]);
                        }
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "JOIN")
                {
                    string session = lines[1];
                    string room_code = lines[2];
                    int user_id = CheckSession(session);
                    int room_id = CheckRoomCode(room_code);

                    if (user_id > -1 && room_id > -1)
                    {
                        Write(ref client, "OK");
                        this.clients[user_id].room_code = room_code;
                    }
                    else
                    {
                        Write(ref client, "INVALID");
                    }
                }
                else if (lines[0] == "CREATE")
                {
                    // Check if the given session key is valid
                    string session = lines[1];
                    int user_id = CheckSession(session);
                    if (user_id > -1)
                    {
                        // If this user has already requested a room but encountered a timeout event,
                        // join the user to that room.
                        if (this.clients[user_id].room_code != "")
                        {
                            Write(ref client, "CHATTING\n" + session + '\n' + this.clients[user_id].room_code);
                        }
                        else
                        {
                            // Randomly create a unique room code
                            string room_code = (new Random().Next() % 10000).ToString();
                            while (CheckRoomCode(room_code) > -1)
                            {
                                room_code = (new Random().Next() % 10000).ToString();
                            }

                            status = "OK";
                            reply = status + '\n' + session + '\n' + room_code;
                            Write(ref client, reply);

                            this.rooms.Add(new Room(room_code));
                            this.clients[user_id].room_code = room_code;
                            this.log += "[ROOM STATUS] Room " + room_code + " has just been created.\n";
                        }
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "MESSAGE")
                {
                    int user_id = CheckSession(lines[1]);
                    int room_id = CheckRoomCode(lines[2]);
                    if (user_id > -1 && room_id > -1)
                    {
                        Write(ref client, "OK");

                        this.rooms[room_id].contents += ">> " + this.clients[user_id].username + ":\n";
                        for (int i = 3; i < lines.Length; ++i)
                        {
                            this.rooms[room_id].contents += lines[i] + '\n';
                        }
                        this.rooms[room_id].contents += "---------------------------------------------------------\n";
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "LOGOUT")
                {
                    // Check if user session is valid
                    int user_id = CheckSession(lines[1]);

                    // If valid
                    if (user_id > -1)
                    {
                        string username = this.clients[user_id].username;
                        string room_code = this.clients[user_id].room_code;

                        // Remove session
                        this.clients[user_id].sessions.Remove(lines[1]);

                        // Check if user has no session
                        if (this.clients[user_id].sessions.Count == 0)
                        {
                            this.clients.RemoveAt(user_id);
                            this.log += "[USER STATUS] " + username + " has just logged out.\n";

                            // Remove room if no active user
                            int room_id = CheckRoomCode(room_code);
                            if (room_id > -1)
                            {
                                int active_user = CountActiveUserOfRoom(room_code);
                                if (active_user == 0)
                                {
                                    this.rooms.RemoveAt(room_id);
                                    this.log += "[ROOM STATUS] Room " + room_code + " has just been closed.\n";
                                }
                            }
                        }
                    }
                }
                else if (lines[0] == "UPDATE CONTENTS")
                {
                    string session = lines[1];
                    int room_indx = CheckRoomCode(lines[2]);
                    if (CheckSession(session) > -1 && room_indx > -1)
                    {
                        Write(ref client, "OK");
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "UPDATE MESSAGE")
                {
                    string session = lines[1];
                    int user_id = CheckSession(session);
                    int room_indx = CheckRoomCode(lines[2]);

                    if (user_id > -1 && room_indx > -1)
                    {
                        // Get new message for client
                        int start = int.Parse(lines[3]);
                        string[] cnt_lines = this.rooms[room_indx].contents.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                        // Send new messages
                        status = "MESSAGE";
                        while (start < cnt_lines.Length)
                        {
                            reply = status + '\n' + cnt_lines[start];
                            Write(ref client, reply);

                            msg = Read(ref client);
                            if (msg != "MESSAGE OK")
                            {
                                break;
                            }
                            ++start;
                        }
                        Write(ref client, "END MESSAGE");
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "UPDATE USERS")
                {
                    string session = lines[1];
                    string room_code = lines[2];
                    int user_id = CheckSession(session);
                    int room_id = CheckRoomCode(room_code);

                    if (user_id > -1 && room_id > -1)
                    {
                        status = "ADD USERS";
                        foreach (Client c in this.clients)
                        {
                            if (c.room_code == lines[2])
                            {
                                reply = status + "\n" + c.username;
                                Write(ref client, reply);

                                msg = Read(ref client);
                                if (msg != "ADD USERS OK")
                                {
                                    break;
                                }
                            }
                        }
                        Write(ref client, "END ADDING USERS");
                    }
                    else
                    {
                        Write(ref client, "ERROR");
                    }
                }
                else if (lines[0] == "LOGIN TIMEOUT")
                {
                    string[] credential = lines[1].Split(';');
                    if (CheckCredential(credential[0], credential[1]))
                    {
                        for (int i = 0; i < this.clients.Count; ++i)
                        {
                            if (this.clients[i].username == credential[0])
                            {
                                this.clients[i].sessions.RemoveAt(this.clients[i].sessions.Count - 1);
                                this.log += "[USER STATUS] " + credential[0] + " has encountered a timeout event. Removing session...\n";

                                if (this.clients[i].sessions.Count == 0)
                                {
                                    this.log += "[USER STATUS] " + this.clients[i].username + " has just logged out.\n";
                                    this.clients.RemoveAt(i);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (lines[0] == "CREATE TIMEOUT")
                {
                    int user_id = CheckSession(lines[1]);
                    if (user_id > -1)
                    {
                        int room_id = CheckRoomCode(this.clients[user_id].room_code);
                        if (room_id > -1)
                        {
                            this.log += "[USER STATUS] A timeout event has occurred while creating room "
                                + this.rooms[room_id].room_code
                                + ". Removing room...\n";
                            this.rooms.RemoveAt(room_id);
                        }
                        this.clients[user_id].room_code = "";
                    }
                }
                else
                {
                    Write(ref client, "UNKNOWN ERROR");
                }
            }
            catch (Exception e)
            {
            }

            UpdateLog();
        }

        private void StartListening()
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                this.listener.Start();
                this.log += "[SERVER STATUS] Start listening...\n";
                UpdateLog();

                while (true)
                {
                    if (this.listener != null)
                    {
                        var client = this.listener.AcceptTcpClient();
                        Thread client_thread = new Thread(() => HandleClient(ref client));
                        client_thread.Start();
                        client_thread.Join();
                        client.Close();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                // MessageBox.Show("Exception from StartListening");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.listener == null)
            {
                this.listener = new TcpListener(IPAddress.Any, 9999);
                this.clients = new List<Client>();
                this.rooms = new List<Room>();

                CheckForIllegalCrossThreadCalls = false;
                Thread listening_thread = new Thread(StartListening);
                listening_thread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listener != null)
                {
                    this.listener.Stop();
                    this.listener = null;
                    this.log += "[SERVER STATUS] Stop listening.\n";
                    UpdateLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception from btnStop " + ex.Message);
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.listener != null)
                {
                    this.listener.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server form closing: " + ex.Message);
            }
        }
    }
}
