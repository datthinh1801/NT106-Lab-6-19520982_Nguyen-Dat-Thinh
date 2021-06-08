using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    class Room
    {
        public string room_code { get; set; }
        public string contents { get; set; }

        public Room(string code)
        {
            this.room_code = code;
            this.contents = "";
        }
    }
}
