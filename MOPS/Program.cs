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


            List<Event> eventsList = new List<Event>();
            List<Package> queue = new List<Package>();

            UserGUI();

            Server server = new Server(Parameters.serverBitRate);

            Parameters.CalculateServerTime();
            Parameters.CalculateTimeBetweenPackages();
            Parameters.PrintAllParameters();

            eventsList = InitializeEventsList(eventsList);
            sortList(eventsList);
            PrintEventList(eventsList);

            bool tmp = false;
            bool running = true;
            Package package = null;
            int i = 0;
            while (running)
            {

                package = eventsList[i].createPackage(i);
                Statistic.incrementRecivedPackage();
                Statistic.Time = package.comingTime;
                
                

                if (server.bussyTime <= Statistic.Time && tmp == true) // jesli jest juz czas zakonczyc obsluge
                {
                    eventsList.Add(CreateFinishEvent(server, server.getPackage()));
                }
                tmp = true;



                if (server.bussy) // serwer zajety
                {
                    if (queue.Count() < Parameters.queueSize)  // jest miejsce w kolejce
                    {
                        package.addToQueueTime = Statistic.Time;
                        queue.Add(package);
                        Statistic.incrementPackageInQueue();

                    }
                    else // nie ma miejsca w kolejce
                    {
                        Statistic.incrementLostPackage();
                    }

                }
                else // serwer wolny
                {
                    if (queue.Count == 0) // kolejka pusta
                    {
                        //opoznienie na 0
                        //+1 do licznika opoznien
                        server.setBussy();
                        server.addPackageToServer(package);
                        server.setBussyTime(Parameters.serverTime + Statistic.Time);

                    }
                    else // Cos jest w kolejce
                    {

                        if (package.ID == server.getPackage().ID)
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            queue.Add(package);
                        }
                        server.setBussy();
                        server.setBussyTime(Parameters.serverTime + Statistic.Time);
                        server.addPackageToServer(queue[0]);
                        queue[0].getFromQueueTime = Statistic.Time;
                        queue.RemoveAt(0);
                    }

                }
                i++;
                if (i >= Statistic.packagesInSimulation )
                { // jesli serwer zajety trzeba uwzglednic paczke w nim 
                   var max = queue.Count();
                    for (int j = 0; j < max; j++)
                    {
                        server.run(queue[j]);
                        eventsList.Add(CreateFinishEvent(server, queue[j]));
                        
                    }
                    running = false;
                    break;
                }
                
            }
            sortList(eventsList);

            Parameters.PrintMainParameters();
            PrintEventList(eventsList);
            Statistic.printStatistic();

            Logs.SaveEventList(eventsList);
            Logs.SaveStatistic();
            Logs.SaveServerParameters();




            /*

            for (int i = 0; i < Statistic.packagesInSimulation; i++)
            {

                Statistic.incrementRecivedPackage(); 
               
            if (server.bussy) // Serwer zajety
            {
                    if (queue.Count() < Parameters.queueSize)  // jest miejsce w kolejce
                    {
                        Package package = eventsList[i].createPackage(Parameters.packageSize);
                        package.addToQueueTime = Statistic.Time;
                        queue.Add(package);
                        Statistic.incrementPackageInQueue();

                    }
                    else // nie ma miejsca w kolejce
                    {
                        Statistic.incrementLostPackage();
                    }

            }
            else // serwer wolny
            {

                    if (queue.Count == 0) // kolejka pusta
                    {
                        //opoznienie na 0
                        //+1 do licznika opoznien
                        server.Bussy();
                        serverBussyTime = Parameters.serverTime + Statistic.Time;
                        
                    }
                    else // Cos jest w kolejce
                    {
                        server.Bussy();
                        queue[0].getFromQueueTime = Statistic.Time;
                        server.run(queue[0]);
                        Console.WriteLine("Actual time:" + Statistic.Time);
                        Event ev = new Event(queue[0].sourceID, "Finish", Statistic.Time);
                        eventsList.Add(ev);
                        server.Available();
                        queue.RemoveAt(0);

                    }
            }

                
            }*/



        }


        static Event CreateFinishEvent(Server server, Package package )
        {
            //server.run(package);
            Console.WriteLine("Actual time:" + Statistic.Time);
            Event ev = new Event(package.sourceID, "Finish", Statistic.Time);
            server.setAvailable();
            return ev;
        }

        static void PrintEventList(List<Event> events)
        {
            Console.WriteLine("[EVENT LIST]");
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine("Source ID: " + events[i].sourceID + " Time: " + events[i].time + "Type: " + events[i].type);
            }
        }

        static List<Event> InitializeEventsList(List<Event> events)
        {
            
            for (int s = 1; s <= Parameters.numberOfSources; s++)
                {
                    float tmpTime = 0;
                    for (int p = 0; p < Parameters.numberOfPackages; p++)
                    {
                        Event e = new Event(s, "Coming", tmpTime);
                        events.Add(e);
                        tmpTime = tmpTime + Parameters.timeBetweenPackages;
                    }
                }
                return events;
        }

        static List<Event> sortList(List<Event> list)
        {
            list.Sort((x, y) => x.time.CompareTo(y.time));
            return list;
        }


        static void UserGUI()
        {
            String command;

            Console.WriteLine("Server bit rate:");
            Parameters.serverBitRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Queue size:");
            Parameters.queueSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Number of sources:");
            Parameters.numberOfSources = int.Parse(Console.ReadLine());

            Console.WriteLine("Select type of source:");
            Console.WriteLine("1-> ON/OFF type");
            Console.WriteLine("2-> CBR type");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":

                    Console.WriteLine("peak rate: ");
                    Parameters.peakRate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Package size: ");
                    Parameters.packageSize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Off time: ");
                    Parameters.OFFtime = int.Parse(Console.ReadLine());
                    Console.WriteLine("Number of package: ");
                    Parameters.numberOfPackages = int.Parse(Console.ReadLine());
                    Statistic.packagesInSimulation = Parameters.numberOfSources * Parameters.numberOfPackages;
                    Logs.SaveONOFFInputParameters();
                    break;

                case "2":

                    Console.WriteLine("peak rate: ");
                    Parameters.peakRate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Package size: ");
                    Parameters.packageSize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Number of package: ");
                    Parameters.numberOfPackages = int.Parse(Console.ReadLine());
                    Statistic.packagesInSimulation = Parameters.numberOfSources * Parameters.numberOfPackages;
                    Logs.SaveCBRInputParameters();
                    break;

                default:
                    Console.WriteLine("Wrong command");
                    break;

            }


        }




















    }
}
