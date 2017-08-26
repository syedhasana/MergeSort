using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace MergeSort
{
    class Program
    {
        public int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int middle = array.Length / 2;
            int [] left,right;
            left = MergeSort(array.Take(middle).ToArray());
            right = MergeSort(array.Skip(left.Length).ToArray());
            return Merge(left, right);
        }

 public int[] Merge(int[] left, int[] right)
        {
            int [] num = new int[left.Length + right.Length];
            int LeftPtr = 0, RightPtr = 0, numPtr = 0;
            while (LeftPtr < left.Length || RightPtr < right.Length)
            {
                if (LeftPtr == left.Length)
                {
                    num[numPtr] = right[RightPtr];
                    RightPtr++;
                }
                else if (RightPtr == right.Length)
                {
                    num[numPtr] = left[LeftPtr];
                    LeftPtr++;
                }
                else if (left[LeftPtr] <= right[RightPtr])
                {
                    num[numPtr] = left[LeftPtr];
                    LeftPtr++;
                }
                else
                {
                    num[numPtr] = right[RightPtr];
                    RightPtr++;
                }
                numPtr++;
            }
            return num;
        }
 
        static void Main(string[] args)
        {
            Program prg = new Program();
            int[] randomNumbers = new int[20];
            Random r = new Random();
            for(int i=0; i < randomNumbers.Length; i++)
                randomNumbers[i] = r.Next(10, 1000);    
            int [] num2 = prg.MergeSort(randomNumbers);
            foreach (int a in num2)
                Console.Write(a + ", ");

        }   
    }
}
