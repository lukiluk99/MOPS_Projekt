using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS.Sources
{
    public class CBR_Source
    {
        public int ID { get; set; }
        public int peakRate { get; set; }
        public int packageSize { get; set; }
        public int timeBetweenPackages { get; set; }
        public int numberOfPackages { get; set; }

        public CBR_Source()
        { }

        public CBR_Source(int ID, int peakRate, int packageSize, int numberOfPackages)
        {
            this.ID = ID;
            this.peakRate = peakRate;
            this.packageSize = packageSize;
            this.timeBetweenPackages = packageSize/peakRate;
            this.numberOfPackages = numberOfPackages;
        }

        public Package createPackage(int time)
        {
            Package package = new Package(ID,packageSize,time);
            
            return package;
        }

        public Event createEvent(String type, int time)
        {
            Event e = new Event(ID, type, time);

            return e;
        }

    }
}
