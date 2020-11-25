using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
    class Package
    {
        
        public int size { get; set; }
        public int comingTime { get; set; }

        public Package()
        {
        }

        public Package(int size, int time)
        {
            this.size = size;
            this.comingTime = time;
            Console.WriteLine("new Package! size: " + size );
        }

    }
}
