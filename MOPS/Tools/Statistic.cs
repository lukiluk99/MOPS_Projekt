using System;
using System.Collections.Generic;
using System.Text;

namespace MOPS.Tools
{
   public static class Statistic
    {


        public static int NumberOfRecivedPackage = 0;

        public static int NumberOfLostPackage = 0;

        public static int NumberOfPackageinQueue = 0;

        public static float Time = 0;

        public static int packagesInSimulation = 0;
        public static int packageSize = 0;

        // -------------------------------------Inceremnt--------------------------------
        public static void incrementRecivedPackage()
        {
            NumberOfRecivedPackage = NumberOfRecivedPackage + 1;
        }

        public static void incrementLostPackage()
        {
            NumberOfLostPackage = NumberOfLostPackage + 1;
        }

        public static void incrementPackageInQueue()
        {
            NumberOfPackageinQueue = NumberOfPackageinQueue + 1;
        }

        public static void incrementTime(float deltaT)
        {
            Time = Time + deltaT;
        }

        //--------------------------------------------Decrement-------------------------------------
        public static void decrementRecivedPackage()
        {
            NumberOfRecivedPackage = NumberOfRecivedPackage - 1;
        }

        public static void decrementLostPackage()
        {
            NumberOfLostPackage = NumberOfLostPackage - 1;
        }

        public static void decrementPackageInQueue()
        {
            NumberOfPackageinQueue = NumberOfPackageinQueue - 1;
        }

        //----------------------------------------Reset------------------------------------------
        public static void resetPackageInQueue()
        {
            NumberOfPackageinQueue = 0;
        }

        public static void resetRecivedPackage()
        {
            NumberOfRecivedPackage = 0;
        }

        public static void resetLostPackage()
        {
            NumberOfLostPackage =0;
        }





    }
}
