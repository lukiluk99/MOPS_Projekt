using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
    class Server
    {
        public bool bussy { get; set; }
        public int serviceTime { get; set; }

        public Server()
        {
            this.bussy = false;
            serviceTime = 10;
        }

        public Server(int time)
        {
            this.serviceTime = time;
        }

       


    }
}
