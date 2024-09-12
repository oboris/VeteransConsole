using System;

namespace NumToArray
{
    internal class Program
    {
        static int[] array = {10, 9, 8, 1, 6, 4, 4 ,3, 2, 1};

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++) 
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        static int[] BubbleSort()
        {
            int k1 = 0;
            for (int j = 0; j < array.Length - 1; j++)
            {
                bool flag = true;
                for (int i = 0; i < array.Length - 1 - j; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        //int tmp = array[i];
                        //array[i] = array[i + 1];
                        //array[i + 1] = tmp;

                        (array[i], array[i + 1]) = (array[i + 1], array[i]);

                        k1++;
                        flag = false;
                    }
                }
                PrintArray(array);
                if (flag)
                {
                    break;
                }
            }

            Console.WriteLine(k1);
            return array;
        }

        static int count = 0;

        static int MinIndexArray(int startIndex)
        {
            int minIndex = startIndex;
            for (int i = startIndex + 1; i< array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
                count ++;
            }

            return minIndex;
        }

        static int[] ChoiseSort()
        {
           int k1 = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = MinIndexArray(i);
                //if (minIndex != i)
                {
                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                    k1++;
                }

                PrintArray(array);
            }
            Console.WriteLine(count);
            Console.WriteLine(k1);
            return array;
        }

        static int[] InsertSort()
        {
            int k1 = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int position = 0;
                while (array[i] > array[position])
                {
                    position++;
                }

                if (position != i)
                {
                    int tmp = array[i];
                    for (int j = i; j > position; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[position] = tmp;
                }
            }
            
            Console.WriteLine(k1);
            return array;
        }

        static void QuickSort(int leftIndex, int rightIndex)
        {
            int pivot = array[(leftIndex + rightIndex) / 2];

            Console.WriteLine($"Left = {leftIndex}, right = {rightIndex}, Pivot = {pivot}");
            int i = leftIndex;
            int j = rightIndex;

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
                PrintArray(array);
            }

            if (leftIndex < j)
            {
                QuickSort(leftIndex, j);
            }

            if (rightIndex > i)
            {
                QuickSort(i, rightIndex);
            }

        }

        static long NewPow(int x, int n)
        {
            long p = 1;
            for (int i = 1; i <=n; i++)
            {
                p *= x;
            }
            return p;
        }

        static long NewPowRecursion(int x, int n)
        {
            /*if (n == 0)
            {
                return 1;
            }
            return x * NewPowRec(x, n - 1);*/
            return n == 0 ? 1 : x * NewPowRecursion(x, n - 1);
        }

        static long SumRecursion(int[] array, int len)
        {
            if (len == 1)
            {
                return array[0];
            }
            return array[len - 1] + SumRecursion(array, len - 1);
        }

        static void Main(string[] args)
        {

            //Console.WriteLine(NewPow(1, 3000));
            //Console.WriteLine(NewPowRecursion(1, 3000));

            //Console.WriteLine(SumRecursion(array, array.Length));

            PrintArray(array);

            //int[] arr = BubbleSort();
            //int[] arr = ChoiseSort();
            //int[] arr = InsertSort();
            QuickSort(0, array.Length - 1);
            PrintArray(array);
            //arr = array;

            //int[] arr = new int[7];

            //for (int i = 0; i < array.Length; i++)
            //{
            //    arr[i] = array[i]; 
            //}
            //PrintArray(arr);

            //arr[0] = 100;
            //array[1] = 100;
            //PrintArray(arr);
            //PrintArray(array);
        }
    }
}