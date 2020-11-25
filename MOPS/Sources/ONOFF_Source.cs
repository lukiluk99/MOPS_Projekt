using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS.Sources
{
    class ONOFF_Source
    {
        public int numberOfPackages { get; set; }
        public int packageSize { get; set; }
        public int peakRate { get; set; }
        public int OFFtime { get; set; }

        public ONOFF_Source(int peakRate, int packageSize, int OFFtime, int numberOfPackages)
        {
            this.peakRate = peakRate;
            this.packageSize = packageSize;
            this.OFFtime = OFFtime;
            this.numberOfPackages = numberOfPackages;
        }

        public Package createPackage()
        {
            Package package = new Package(packageSize, 10);


            return package;
        }

    }
}
