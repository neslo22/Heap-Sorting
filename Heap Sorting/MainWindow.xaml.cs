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

namespace Heap_Sorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HeapSort hs = new HeapSort();
        private int[] input = new int[] { 8, 9, 4, 5, 6 };

        public MainWindow()
        {
            InitializeComponent();
            
            buildTree(input);
            hs.PerformHeapSort(input);
        }
        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void buildTree(int[] input) //just a gui implementation of heapsort
        {
            Ellipse[] node = new Ellipse[input.Length];
            Label[] nodeValue = new Label[input.Length];
            Line[] connectNode = new Line[input.Length - 1];

            int currentNode = 0, tempNodeCounter = 0, tempNodeTotal = 2; 
            double currentNodeLeft = 325;

            for (int x = 0; x < input.Length; x++)
            {
                node[x] = new Ellipse() { Width = 40, Height = 40, Fill = Brushes.White, Stroke = Brushes.Black, StrokeThickness = 2 };
                nodeValue[x] = new Label() { Content = input[x]};
                if(x < input.Length - 1)
                {
                    connectNode[x] = new Line { StrokeThickness = 2, Stroke = Brushes.Black };
                }
            }
            for (int x = 0; x < input.Length;)
            {
                if(currentNode == 0)
                {
                    Canvas.SetTop(node[x], 2);
                    Canvas.SetLeft(node[x], 640);
                    Canvas.SetTop(nodeValue[x], 7);
                    Canvas.SetLeft(nodeValue[x], 640);
                    canvasTree.Children.Add(node[x]);
                    canvasTree.Children.Add(nodeValue[x]);
                    x += 1;
                }                                
                if (x < input.Length && x != 0)
                {                    
                    Canvas.SetTop(node[x], Canvas.GetTop(node[currentNode]) + 75);
                    Canvas.SetLeft(node[x], Canvas.GetLeft(node[currentNode]) - currentNodeLeft);
                    Canvas.SetTop(nodeValue[x], Canvas.GetTop(nodeValue[currentNode]) + 75);
                    Canvas.SetLeft(nodeValue[x], Canvas.GetLeft(nodeValue[currentNode]) - currentNodeLeft);                    

                    connectNode[x-1].Y1 = Canvas.GetTop(node[x]) + 2;
                    connectNode[x-1].X1 = Canvas.GetLeft(node[x]) +20;

                    connectNode[x-1].Y2 = Canvas.GetTop(node[currentNode]) +39;
                    connectNode[x-1].X2 = Canvas.GetLeft(node[currentNode]) + 20;

                    canvasTree.Children.Add(connectNode[x - 1]);
                    canvasTree.Children.Add(node[x]);
                    canvasTree.Children.Add(nodeValue[x]);

                    tempNodeCounter++;

                    if (x + 1 < input.Length)
                    {
                        Canvas.SetTop(node[x + 1], Canvas.GetTop(node[currentNode]) + 75);
                        Canvas.SetLeft(node[x + 1], Canvas.GetLeft(node[currentNode]) + currentNodeLeft);
                        Canvas.SetTop(nodeValue[x + 1], Canvas.GetTop(nodeValue[currentNode]) + 75);
                        Canvas.SetLeft(nodeValue[x + 1], Canvas.GetLeft(nodeValue[currentNode]) + currentNodeLeft);

                        connectNode[x].Y1 = Canvas.GetTop(node[x+1]) + 2;
                        connectNode[x].X1 = Canvas.GetLeft(node[x+1]) +20;

                        connectNode[x].Y2 = Canvas.GetTop(node[currentNode]) + 39;
                        connectNode[x].X2 = Canvas.GetLeft(node[currentNode]) + 20;

                        canvasTree.Children.Add(connectNode[x]);
                        canvasTree.Children.Add(node[x + 1]);
                        canvasTree.Children.Add(nodeValue[x + 1]);
                        x += 2;
                        currentNode += 1;
                        tempNodeCounter++;
                    }
                    else { currentNode += 1; x += 1; }

                    if(tempNodeCounter == tempNodeTotal)
                    {
                        tempNodeCounter = 0;
                        currentNodeLeft /= 2;
                        tempNodeTotal *= 2;
                    }
                        
                }                
            }
            async Task PutTaskDelay()
            {
                await Task.Delay(50);
            }
        }
        int ind = 0, tempInd=0;
        Boolean output1Done = false, output2Done = false;

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            int[] temp = new int[input.Length];
            Console.WriteLine();            
            if (!output1Done)
            {
                canvasTree.Children.Clear();
                if (ind == 0 )
                {
                    ind = hs.output1.GetLength(0) - 1;
                }
                for (int j = 0; j < input.Length; j++)
                {
                    temp[j] = hs.output1[ind, j];
                    Console.Write(hs.output1[ind, j] + " ");
                }
                ind--;
                buildTree(temp);
                Console.WriteLine();
                if (ind == 0)
                    output1Done = true;
            }
            else if(output1Done && !output2Done)
            {
                temp = new int[input.Length];
                canvasTree.Children.Clear();
                if (ind == 0 )
                {
                    ind = hs.output2.GetLength(0) - 2;
                }
                for (int j = 0; j < input.Length; j++)
                {
                    temp[j] = hs.output2[ind, j];
                    Console.Write(hs.output2[ind, j] + " ");
                }
                ind--;
                buildTree(temp);
                Console.WriteLine();
                if (ind == 0)
                    output2Done = true;
            }
        }
    }
}
/*
 * if (x == 0)
                {
                    Canvas.SetTop(node[x], 10);
                    Canvas.SetLeft(node[x], 450);
                    Canvas.SetTop(nodeValue[x], 20);
                    Canvas.SetLeft(nodeValue[x], 468);                    
                }
                else
                {
                    for (int y = 0; y < input.Length / 2; y++)
                    {
                        Canvas.SetTop(node[x], Canvas.GetTop(node[x - 1]) + 75);
                        Canvas.SetLeft(node[x], Canvas.GetLeft(node[x - 1]) - 75);
                        Canvas.SetTop(nodeValue[x], Canvas.GetTop(node[x - 1]) + 85);
                        Canvas.SetLeft(nodeValue[x], Canvas.GetLeft(node[x - 1]) - 60);
                    }
                }
                
 * */
