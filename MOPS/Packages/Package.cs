using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS
{
    class Package
    {
        
        public int size { get; set; }

        public Package()
        {
        }

        public Package(int size)
        {
            this.size = size;
            Console.WriteLine("new Package! size: " + size );
        }

    }
}
