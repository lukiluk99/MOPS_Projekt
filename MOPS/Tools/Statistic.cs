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

        public static void increaseRecivedPackage()
        {
            NumberOfRecivedPackage = NumberOfRecivedPackage + 1;
        }

        public static void increaseLostPackage()
        {
            NumberOfLostPackage = NumberOfLostPackage + 1;
        }

        public static void increasePackageInQueue()
        {
            NumberOfPackageinQueue = NumberOfPackageinQueue + 1;
        }

    }
}
