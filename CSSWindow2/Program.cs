using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSWindow2
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
            foreach (string stringy in substrings)
            {
                numbers.Add(int.Parse(stringy));
            }

            for (int t = 0; t < testNumber; t++)
            {
                temp = Console.ReadLine();
                substrings = temp.Split(' ');

                numbers[(int.Parse(substrings[0])) - 1] = int.Parse(substrings[1]);
                CheckerManager.distance = numbers.Count + 1;
                findSmallestWindow(typeNumber);

                CheckerManager.checkerList.Clear();
            }
        }

        public static int findSmallestWindow(int typeNumber)
        {

            int actualType = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (actualType != numbers[i] && i > 0)
                {
                    actualType = numbers[i];
                    Checker newChecker = new Checker(i, typeNumber);
                    CheckerManager.checkerList.Add(newChecker);

                    if (i > 2 && numbers[i - 1] == numbers[i - 2])
                    {
                        Checker newChecker2 = new Checker(i - 1, typeNumber);
                        newChecker2.typeSet.Add(numbers[i - 1]);
                        CheckerManager.checkerList.Add(newChecker2);
                    }

                    for (int j = 0; j < CheckerManager.checkerList.Count; j++)
                    {
                        if (CheckerManager.checkerList[j].typeCounter(actualType, i) < CheckerManager.distance)
                        {
                            if (CheckerManager.checkerList[j].IsFinished())
                            {
                                CheckerManager.distance = CheckerManager.checkerList[j].length;
                                CheckerManager.checkerList.RemoveAt(j);
                                j--;
                            }                           
                            
                        } else 
                        {
                            CheckerManager.checkerList.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }

            if (CheckerManager.distance <= numbers.Count)
            {
                Console.WriteLine(CheckerManager.distance);
                return CheckerManager.distance;
            }
            else
            {
                Console.WriteLine(-1);
                return -1;
            }

        }

    }

    public class CheckerManager
    {
        public static int maxTypeNumber { get; set; }
        //public static List<int> distances = new List<int>();
        public static List<Checker> checkerList = new List<Checker>();
        public static int distance;

        //public CheckerManager(int maxtypenumber) //do i need this? will i need more manager than one?
        //{
        //    maxTypeNumber = maxtypenumber;
        //    distances = new List<int>();
        //    checkerList = new List<Checker>();
        //}


    }

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
            
            length = actualIndex + 1 - startIndex;
            
            return length;
        }

        public bool IsFinished()
        {
            if(typeSet.Count == maxTypeNumber)
            {
                return true;
            }
            return false;
        }
    }
}
