using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
   public class Package
    {

        public int sourceID { get; set; }
        public int size { get; set; }
        public int comingTime { get; set; }
        public int addToQueueTime { get; set; }
        public int getFromQueueTime { get; set; }
        public Package()
        {
        }

        public Package(int sourceID, int size, int time)
        {
            this.size = size;
            this.comingTime = time;
            this.addToQueueTime = 0;
            this.getFromQueueTime = 0;
            this.sourceID = sourceID;
            Console.WriteLine("new Package! size: " + size );
        }

    }
}
