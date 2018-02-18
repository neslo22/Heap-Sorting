using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sorting
{
    class HeapSort
    {
        private int stepCounter = 0;
        private bool done = false;
        public int[,] history;

        public void sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            for (int i = n-1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
                if(i == 0 && done)
                {
                    for (int j = 0; j < arr.Length; j++)
                        history[stepCounter, j] = arr[j];
                }
            }
        }
        void heapify(int[] arr, int n, int i)
        {
            int largest = i, left = 2*i+1, right = 2*i+2;

            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                if (done)
                {
                    for (int x = 0; x < arr.Length; x++)
                        history[stepCounter, x] = arr[x];
                }
                stepCounter++;

                heapify(arr, n, largest);
            }
        }
        public int[,] getHeap(int[] arr)
        {
            int[] temp = new int [arr.Length];
            for (int i = 0; i < arr.Length; i++)
                temp[i] = arr[i];
            sort(arr);
            history = new int[stepCounter + 1, arr.Length];
            done = true;
            stepCounter = 0;
            sort(temp);
            return history;
        }
    }
}
