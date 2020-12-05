using MOPS.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
   public class Server
    {
        public bool bussy { get; set; }
        public int bitRate { get; set; }

        public Server()
        {

        }

        public Server(int bitRate)
        {
            this.bussy = false;
            this.bitRate = bitRate;
        }

        public void run(Package package)
        {
            var time = package.size/bitRate;
            Statistic.incrementTime(time);
            Console.WriteLine("Server Working");

        }

        public void Bussy()
        {
            bussy = true;
        }

        public void Available()
        {
            bussy = false;
        }

       


    }
}
