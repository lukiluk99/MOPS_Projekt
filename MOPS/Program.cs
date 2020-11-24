using MOPS.Sources;
using System;
using System.Collections.Generic;

namespace MOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CBR_Source> cbrSourcesList = new List<CBR_Source>();
            List<ONOFF_Source> ONOFFSourcesList = new List<ONOFF_Source>();
            List<Event> events = new List<Event>();

            int numberOfSources;
            String command;
            int peakRate;
            int packageSize;
            int OFFtime;
            int numberOfPackages;
            int timeBetweenPackages;

            Console.WriteLine("Number of sources:");
            numberOfSources = int.Parse(Console.ReadLine());
            Console.WriteLine("Select type of source:");
            Console.WriteLine("1-> ON/OFF type");
            Console.WriteLine("2-> CBR type");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    for (int i = 0; i < numberOfSources; i++)
                    {
                        Console.WriteLine("\n Source: " + (i + 1));
                        Console.WriteLine("peak rate: ");
                        peakRate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Package size: ");
                        packageSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Off time: ");
                        OFFtime = int.Parse(Console.ReadLine());
                        Console.WriteLine("Number of package: ");
                        numberOfPackages = int.Parse(Console.ReadLine());
 
                        ONOFF_Source source = new ONOFF_Source(peakRate, packageSize, OFFtime, numberOfPackages);
                        ONOFFSourcesList.Add(source);
                    }
                    break;

                case "2":
                    for (int i = 0; i < numberOfSources; i++)
                    {
                        Console.WriteLine("peak rate: ");
                        peakRate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Package size: ");
                        packageSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Off time: ");
                        timeBetweenPackages = int.Parse(Console.ReadLine());
                        Console.WriteLine("Number of package: ");
                        numberOfPackages = int.Parse(Console.ReadLine());
                        CBR_Source source = new CBR_Source(peakRate, packageSize, timeBetweenPackages, numberOfPackages);
                        cbrSourcesList.Add(source);
                    }
                    break;

                default:
                    Console.WriteLine("Wrong command");
                    break;
            
            }

            while (true)
            {
                




















                /*
                if (command == "1") //  ON/OFF source
                {
                    for (int i = 0; i < ONOFFSourcesList.Count; i++)
                    {
                        ONOFFSourcesList[i].createPackage();

                    }
                }
                else if (command == "2") // CBR
                {
                    for (int i = 0; i < cbrSourcesList.Count; i++)
                    {
                        cbrSourcesList[i].createPackage();

                    }
                }*/

             
            
            }

           


            

              

            
        }
    }
}
