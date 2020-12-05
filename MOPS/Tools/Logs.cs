using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using MOPS.Sources;

namespace MOPS.Tools
{
    public class Logs
    {

        public static void SaveCBRInputParameters(CBR_Source source, int numberOfSources)
        {
            String log;

            log = $"Number od sources: {numberOfSources}\n\n [INPUT PARAMETERS]\n Package size: {source.packageSize}\n Time between packages: {source.timeBetweenPackages}\n Number of packages: {source.numberOfPackages}\n";

            WriteToFile(log);
        }

        public static void SaveONOFFInputParameters(ONOFF_Source source, int numberOfSources)
        {
            String log;

            log = $"Number od sources: {numberOfSources}\n\n [INPUT PARAMETERS]\n Package size: {source.packageSize}\n OFF time: {source.OFFtime}\n Number of packages: {source.numberOfPackages}\n";

            WriteToFile(log);
        }

        private static void WriteToFile(String log)
        {
            string path = $"./logs/Input parameters.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(log);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(log);
                }
            }

        }


    }
}
