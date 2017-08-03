using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSWindow
{
    class Program
    {
        public static List<int> numbers = new List<int>();
        public static int typeNumber;

        static void Main(string[] args)
        {
            string temp = Console.ReadLine();

            String[] substrings = temp.Split(' ');
            int testNumber = int.Parse(substrings[2]);
            typeNumber = int.Parse(substrings[1]);

            numbers = new List<int>();

            temp = Console.ReadLine();
            substrings = temp.Split(' ');
            foreach(string stringy in substrings)
            {
                numbers.Add(int.Parse(stringy));
            }

            for(int t = 0; t < testNumber; t++)
            {
                temp = Console.ReadLine();
                substrings = temp.Split(' ');

                numbers[(int.Parse(substrings[0])) - 1] = int.Parse(substrings[1]);
                findSmallestWindow(typeNumber);
                CheckerManager.distances.Clear();
                CheckerManager.checkerList.Clear();
            } 
        }

        public static int findSmallestWindow(int typeNumber)
        {
           
            int actualType = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if(actualType != numbers[i] && i > 0)
                {
                    actualType = numbers[i];
                    Checker newChecker = new Checker(i, typeNumber);
                    CheckerManager.checkerList.Add(newChecker);

                    if(i > 2 && numbers[i - 1] == numbers[i - 2])
                    {
                        Checker newChecker2 = new Checker(i - 1, typeNumber);
                        newChecker2.typeSet.Add(numbers[i - 1]);
                        CheckerManager.checkerList.Add(newChecker2);          
                    }

                    for(int j = 0; j < CheckerManager.checkerList.Count; j++)
                    {
                        if (CheckerManager.checkerList[j].typeCounter(actualType, i) > 0) {
                            CheckerManager.distances.Add(CheckerManager.checkerList[j].typeCounter(actualType, i));
                            CheckerManager.checkerList.RemoveAt(j);
                            j--;
                        }
                    }
                }               
            }

            if(CheckerManager.distances.Count > 0) {
                Console.WriteLine(CheckerManager.distances.Min());
                return CheckerManager.distances.Min();
            }
            else {
                Console.WriteLine(-1);
                return -1; }
            
        }

    }
}
