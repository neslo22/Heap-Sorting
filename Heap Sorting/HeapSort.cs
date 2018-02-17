using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sorting
{
    class HeapSort
    {
        public int heapSize;
        public int[,] output1;
        public int[,] output2;

        private void BuildHeap(int[] arr)
        {            
            heapSize = arr.Length - 1;
            output1 = new int[(heapSize / 2 + 1), heapSize + 1];
            Console.WriteLine("Building heap sort");
            for (int i = heapSize / 2; i >= 0; i--)
            {
                //Array.Copy(arr, output1[], heapSize+1);
                for (int j=0; j <= heapSize; j++)
                {
                    output1[i,j] = arr[j];
                }
                //output1[i] = ; // output
                DisplayArray(arr);
                Heapify(arr, i);
                Console.WriteLine();
            }
        }
        private void Swap(int[] arr, int x, int y) //function to swap elements
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(int[] arr, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }
        }
        public void PerformHeapSort(int[] arr)
        {
            BuildHeap(arr); 
            output2 = new int[arr.Length + 1, heapSize + 1];
            Console.WriteLine();
            Console.WriteLine("Performing the heap sort");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= heapSize; j++)
                {
                    output2[i + 1, j] = arr[j];
                }
                DisplayArray(arr);
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Displaying the array");
            DisplayArray(arr);
        }
        private void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            { Console.Write("{0} ", arr[i]); }
        }        
    }
}
