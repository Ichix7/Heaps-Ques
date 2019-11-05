using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer timer = new DispatcherTimer();
        static DispatcherTimer timerbar = new DispatcherTimer();
        public static MaxHeap que = new MaxHeap();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0,0,5);
            timerbar.Tick += Timerbar_Tick;
            timerbar.Interval = new TimeSpan(0, 0, 1);
            timerbar.Start();
            timer.Start();


        }
        /// <summary>
        /// Makes the progress bar go down by 1 sec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timerbar_Tick(object sender, EventArgs e)
        {
            timerBar.Value--;
        }

        /// <summary>
        /// Every 5 seconds the que will pop with the max command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            timerBar.Value = 5;
            Status.Foreground = Brushes.Black;
            switch (que.DeQue())
            {
                case 99:
                    Status.Text = "GoodBye!";
                    System.Windows.Application.Current.Shutdown();
                    break;
                case 10:
                    Status.Text = "Dodge Left!";
                    break;
                case 8:
                    Status.Text = "Jumping";
                    break;
                case 6:
                    Status.Text = "Looking Around";
                    break;
                case 4:
                    Status.Text = "Aim";
                    break;
                case 3:
                    Status.Foreground = Brushes.DarkRed;
                    Status.Text = "Shoot!!!";
                    break;
                case 2:
                    Status.Text = "Walking";
                    break;                
                case 1:
                    Status.Text = "Run!!! Run!!";
                    break;             
                
                case 0:
                    Status.Text = "Click Something!";
                    break;
            }
        }

        public class MaxHeap
        {
            int length = -1;
            
            int[] nums = new int[10];

            /// <summary>
            /// Dsiplays The Que/Array in its fullest
            /// </summary>
            public void Display()
            {
                string s = "";
                foreach (int num in nums)
                {
                    s += num + " ";
                }
                Console.WriteLine(s);
            }

            /// <summary>
            /// Replaces the first number with the last number in the array and then reorganizes it
            /// </summary>
            public int DeQue()
            {
                que.Display();

                if (length < 0)
                {
                    Console.WriteLine("Error: Heap Undeflow");
                    length = 0;
                }  


                    int max = nums[0];
                    nums[0] = nums[length];
                    nums[length] = 0;
                    length = length - 1;
                    MaxHeapify(0);
                
                
                return max;

            }
            /// <summary>
            /// Checks the array length and then sends it ot Increase to find its correct spot
            /// </summary>
            /// <param name="x"></param>
            public void Enque(int x)
            {
                if (length >= 8)
                {
                    Console.WriteLine("Error: Heap OverFlow");
                    length = 8;
                }
                length = length + 1;
                nums[length] = Int32.MinValue;
                HeapIncreaseKey(length, x);
                que.Display();

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
                int large;

                int l = 2 * i + 1;
                int r = 2 * (i) + 2;
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


        
        //Events From the Various Button clicks
        private void Walk_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(2);
        }

        private void Jump_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(8);
        }

        private void Dodge_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(10);
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(1);
        }

        private void Aim_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(4);
        }

        private void Shoot_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(3);
        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(6);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            que.Enque(99);
        }
    }
}
