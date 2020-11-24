using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS.Sources
{
    class CBR_Source
    {
        public int peakRate { get; set; }
        public int packageSize { get; set; }
        public int timeBetweenPackages { get; set; }
        public int numberOfPackages { get; set; }

        public CBR_Source()
        { }

        public CBR_Source(int peakRate, int packageSize, int timeBetweenPackages, int numberOfPackages)
        {
            this.peakRate = peakRate;
            this.packageSize = packageSize;
            this.timeBetweenPackages = timeBetweenPackages;
            this.numberOfPackages = numberOfPackages;
        }

        public Package createPackage()
        {
            Package package = new Package(packageSize);
            

            return package;
        }

    }
}
