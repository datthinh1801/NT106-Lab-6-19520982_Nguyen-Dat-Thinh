using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    class Client
    {
        public string username { get; set; }
        public List<string> sessions { get; set; }
        public string room_code { get; set; }

        public Client()
        {
            username = "";
            sessions = new List<string>();
            room_code = "";
        }
    }
}
