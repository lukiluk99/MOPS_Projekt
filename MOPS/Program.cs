using MOPS.Sources;
using MOPS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CBR_Source> cbrSourcesList = new List<CBR_Source>();
            List<ONOFF_Source> ONOFFSourcesList = new List<ONOFF_Source>();
            List<Event> events = new List<Event>();
            List<Package> queue = new List<Package>();
            Server server = new Server(15);


            int numberOfSources;
            String command;
            int peakRate;
            int packageSize;
            int OFFtime;
            int numberOfPackages;
            int id;
            int queueSize;

            Console.WriteLine("Queue size:");
            queueSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Number of sources:");
            numberOfSources = int.Parse(Console.ReadLine());
            Console.WriteLine("Select type of source:");
            Console.WriteLine("1-> ON/OFF type");
            Console.WriteLine("2-> CBR type");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    
                        Console.WriteLine("peak rate: ");
                        peakRate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Package size: ");
                        packageSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Off time: ");
                        OFFtime = int.Parse(Console.ReadLine());
                        Console.WriteLine("Number of package: ");
                        numberOfPackages = int.Parse(Console.ReadLine());
                    for (int i = 0; i < numberOfSources; i++)
                    {
                        ONOFF_Source source = new ONOFF_Source(peakRate, packageSize, OFFtime, numberOfPackages);
                        ONOFFSourcesList.Add(source);
                    }
                    break;

                case "2":

                        
                        Console.WriteLine("peak rate: ");
                        peakRate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Package size: ");
                        packageSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Number of package: ");
                        numberOfPackages = int.Parse(Console.ReadLine());
                    Statistic.packagesInSimulation = numberOfSources * numberOfPackages;
                    Statistic.packageSize = packageSize;
                    for (int i = 0; i < numberOfSources; i++)
                    {
                        id = i;
                        CBR_Source source = new CBR_Source(id, peakRate, packageSize, numberOfPackages);
                        cbrSourcesList.Add(source);
                    }
                    Logs.SaveCBRInputParameters( new CBR_Source(1, peakRate, packageSize, numberOfPackages), numberOfSources);
                    break;

                default:
                    Console.WriteLine("Wrong command");
                    break;
            
            }


            for(int i = 0; i < Statistic.packagesInSimulation; i++)
            {
                Event e =  cbrSourcesList[0].createEvent("Coming", Statistic.Time);
                Statistic.incrementRecivedPackage(); 
                events.Add(e);

                if (server.bussy) // Serwer zajety
                {
                    if (queue.Count() < queueSize) 
                    {
                        queue.Add(events[0].createPackage( Statistic.packageSize));
                        //queue.Add(cbrSourcesList[e.sourceID].createPackage(Statistic.Time)); 
                        Statistic.incrementPackageInQueue();

                    }
                    else
                    {
                        Statistic.incrementLostPackage();
                    }

                }
                else // serwer wolny
                {
                    //opoznienie na 0
                    //+1 do licznika opoznien
                    server.Bussy();
                    server.run(events[0].createPackage(Statistic.packageSize));
                    Console.WriteLine("Actual time:" + Statistic.Time);
                    Event ev = new Event(events[0].sourceID,"Finish", Statistic.Time);
                    events.Add(ev);
                    server.Available();
                }


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
