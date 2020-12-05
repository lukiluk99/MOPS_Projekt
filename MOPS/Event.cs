using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
   public class Event
    {
        public String type { get; set; }
        public int time { get; set; }
        public int sourceID { get; set; } 
       

        public Event()
        {}

        public Event(int id, String type, int time)
        {
            this.sourceID = id;
            this.type = type;
            this.time = time;
            
        }

        public Package createPackage( int size)
        {
            Package package = new Package(this.sourceID, size, time);

            return package;
        }


    }
}
