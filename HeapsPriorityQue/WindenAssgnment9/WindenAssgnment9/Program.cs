using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindenAssgnment9
{
    class Program
    {
        

        static void Main(string[] args)
        {
            MaxHeap Que = new MaxHeap();

            Que.Enque(15);
            Que.Enque(5);
            Que.Enque(56);
            Que.Enque(58);
            Que.Enque(34);
            Que.Enque(98);
            Que.Enque(4);
            Que.Enque(25);
            Que.Enque(12);
            Que.Enque(7);

            Que.Display();

            Que.DeQue();
            Que.Display();
            Que.DeQue();

            Que.Display();

            Console.ReadLine();
        }

        public class MaxHeap
        {
            int length =-1;
            int large;
            int[] nums = new int[10];

            /// <summary>
            /// Dsiplays The Que/Array in its fullest
            /// </summary>
            public void Display()
            {
                string s = "";
                foreach(int num in nums)
                {
                    s += num + " ";
                }
                Console.WriteLine(s);
            }
            
            /// <summary>
            /// Replaces the first number with the last number in the array and then reorganizes it
            /// </summary>
            public void DeQue()
            {

                if (length < 1)
                {
                    Console.WriteLine("Error: Heap Undeflow");
                }

                int max = nums[0];
                nums[0] = nums[length];
                nums[length] = 0;
                length = length - 1;
                MaxHeapify(0);

            }
            /// <summary>
            /// Checks the array length and then sends it ot Increase to find its correct spot
            /// </summary>
            /// <param name="x"></param>
            public void Enque(int x)
            {
                length = length + 1;
                nums[length] = Int32.MinValue;
                HeapIncreaseKey(length, x);
            }

            static public int parent(int i)
            {
                return (i - 1) / 2;
            }

            /// <summary>
            /// if i is greater than parents swap them, let i now be the parent
            /// </summary>
            /// <param name="i"></param> index in the array
            /// <param name="x"></param>Variable that is being passed in
            public void HeapIncreaseKey(int i, int x)
            {
            
                if (x < nums[i])
                {
                    Console.WriteLine("Error: new key is smaller than current key");
                }
                nums[i] = x;
                while (i > 1 && nums[parent(i)] < nums[i])
                {
                    swap(i, parent(i));
                    i = parent(i);
                }
            }

            public void swap(int a, int b)
            {
                int temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
            }

            /// <summary>
            /// Looks to the left and right of the tree, rearranges it as many times as neccessary
            /// </summary>
            /// <param name="i"></param>
            public void MaxHeapify(int i)
            {
                

                int l = 2*i;
                int r = 2*(i) +1;
                if (l <= length && nums[l] > nums[i])
                {
                    large = l;
                }
                else { large = i; }
                if (r <= length && nums[r] > nums[large])
                {
                    large = r;
                }
                if (large != i)
                {
                    swap(i, large);
                    MaxHeapify(large);
                }
                
            }
        }
    }
}
