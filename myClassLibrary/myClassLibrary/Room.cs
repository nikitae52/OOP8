using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibrary
{
    public class Room
    {
        public int RoomNum { get; set; }
        public int Capacity { get; set; }
        public int FreePlaces => Capacity - Dwellers.Count;
        public List<Person> Dwellers { get; set; } 



        internal Room(int roomNum, int capacity)
        {
            RoomNum = roomNum;
            Capacity = capacity;
            Dwellers = new List<Person>();
        }
    }
}
