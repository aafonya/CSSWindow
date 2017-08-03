using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSSWindow
{
    public class Checker
    {
        public int startIndex { get; set; }
        public int length { get; set; }
        public int maxTypeNumber { get; set; }

        public HashSet<int> typeSet = new HashSet<int>();

        public Checker(int startindex, int maxtypenumber)
        {
            startIndex = startindex;
            maxTypeNumber = maxtypenumber;
            length = 0;
        }

        public int typeCounter(int actualType, int actualIndex)
        {
          
            typeSet.Add(actualType);
            if(typeSet.Count == maxTypeNumber)
            {
                length = actualIndex + 1 - startIndex;               
            }
            return length;
        }
    }
}
