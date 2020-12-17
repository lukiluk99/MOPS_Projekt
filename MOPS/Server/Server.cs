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
        private Package package { get; set; }
        public float bussyTime { get; set; }

        public Server()
        {

        }

        public Server(int bitRate)
        {
            this.bussy = false;
            this.bitRate = bitRate;
            this.package = null;
            this.bussyTime = 0;
        }

        public void run(Package package)
        {
            Statistic.incrementTime(Parameters.serverTime);
            Console.WriteLine("Server Working");

        }

        public void setBussy()
        {
            bussy = true;
        }

        public void setAvailable()
        {
            bussy = false;
        }

        public void setBussyTime(float time)
        {
            this.bussyTime = time;
        }

        public void addPackageToServer(Package package)
        {
            this.package = package;
        }

        public Package getPackage()
        {
            return package;
        }
       


    }
}
