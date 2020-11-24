using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
    class Event
    {
        public String type { get; set; }
        public int time { get; set; }


        public Event()
        {}

        public Event(String type, int time)
        {
            this.type = type;
            this.time = time;
        }


    }
}
