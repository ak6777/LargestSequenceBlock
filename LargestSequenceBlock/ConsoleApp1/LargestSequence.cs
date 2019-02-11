using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestSequence
{
    class Program
    {
        static void Main(String[] args)
        {
            int limit = (args.Length < 100) ? args.Length : 100;
            Program p = new Program();

            //int[] numberArray = new int[limit];
            int[] numberArray = new int[] { 3, 4, 2, 1, -10, -20, -10, -20, -10, -20, 5, 4, 4, 5, 0, 12, 12, 13, 12, 13, 12, 12 };
            //int[] numberArray = new int[] { 5, 4, 4, 5, 0, 12 };

            List<int> sequence = new List<int>();
            bool isSequence = false;
            int largestBiValueFoundTillNow = 0;
            int updatedIndex = 0;

            while (updatedIndex < (numberArray.Count() - 3))
            {
                isSequence = p.AreThreeNumbersUnique(numberArray[updatedIndex], numberArray[updatedIndex + 1], numberArray[updatedIndex + 2]);

                if (isSequence)
                {
                    updatedIndex++;
                    continue;
                }


                if (!isSequence)
                {
                    sequence.Add(numberArray[updatedIndex]);
                    sequence.Add(numberArray[updatedIndex + 1]);
                    sequence.Add(numberArray[updatedIndex + 2]);
                    p.processSequence(ref sequence, numberArray, updatedIndex + 3);

                    if (sequence.Count > largestBiValueFoundTillNow)
                    {
                        largestBiValueFoundTillNow = sequence.Count;
                    }
                    sequence.Clear();
                }

                updatedIndex++;
            }

            Console.WriteLine("larget bi-valued slice found in sequence is: " + largestBiValueFoundTillNow);
            Console.ReadKey();
        }

        public bool AreThreeNumbersUnique(int a, int b, int c)
        {
            //Console.WriteLine("a = " + a + " b = " + b + " c = " + c);
            if ((a != b && a != c) && b != c)
            {
                return true;
            }
            return false;
        }

        public void processSequence(ref List<int> seq, int[] arrNumbers, int index)
        {
            //int newIndex = 0;
            for (int i = index; i < arrNumbers.Length; i++)
            {
                if (seq.Contains(arrNumbers[i]))
                {
                    seq.Add(arrNumbers[i]);
                    continue;
                }
                else
                {
                    //newIndex = i;
                    break;
                }
            }
            //return newIndex;

        }
    }
}
