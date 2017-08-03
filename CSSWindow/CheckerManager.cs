using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSWindow
{
    public class CheckerManager
    {
        public static  int maxTypeNumber { get; set; }
        public static List<int> distances = new List<int>();
        public static List<Checker> checkerList = new List<Checker>();
        public static int distance;

        //public CheckerManager(int maxtypenumber) //do i need this? will i need more manager than one?
        //{
        //    maxTypeNumber = maxtypenumber;
        //    distances = new List<int>();
        //    checkerList = new List<Checker>();
        //}


    }
}
