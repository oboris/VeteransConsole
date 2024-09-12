using System;

namespace task_qbit
{
   
 
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return 
        }
    }
    internal class Program
    {
        static int[] hash = new int[20001];

        private static void CreateHash(int[] arr)
        {
            for (int i = 0; i < hash.Length; i++)
            {
                hash[i] = 0;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                hash[10000 + arr[i]]++;
            }
        }

        private static int CheckDiffernt()
        {
            int count = 0;

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32 (Console.ReadLine());
            string[] line = Console.ReadLine().Split(' ');

            int[] arr = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(line[i]);
            }

            CreateHash(arr);
            Console.WriteLine(CheckDiffernt());
        }
    }
}
