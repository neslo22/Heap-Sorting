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
        private int[,] history;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            buildTree(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            history = hs.getHeap(new int[] { 4, 10, 3, 5, 1 });
            buttonRun.IsEnabled = false;
            buttonNext.IsEnabled = true;
            buttonClear.IsEnabled = true;
        }
        private void  buildTree(int[] input)
        {
            int n = input.Length, height = 10, leavesPerLevel = 1, leftMostNode = 0, leftMostTemp = 0;
            Ellipse[] leaf = new Ellipse[n];
            Label[] nodeValue = new Label[n];
            double divide = 2, widthTemp = 0;

            for (int i = 0; i < n; i++)
            {
                leaf[i] = new Ellipse { Width = 40, Height = 40, Fill = Brushes.White, Stroke = Brushes.Black, StrokeThickness = 1};
                nodeValue[i] = new Label() { Content = input[i] };
            }

            //create root
            createNode(leaf[0], nodeValue[0], 0, height, canvasTree.ActualWidth / 2);
            height += 75; leavesPerLevel *= 2;

            for (int i = 1; i < n;)
            {                
                widthTemp = Canvas.GetLeft(leaf[leftMostNode]) / 2;
                Console.WriteLine("\nWidth Temp: " + widthTemp + " | Leaves Per level: " + leavesPerLevel);
                Console.WriteLine("Who dat leftMostNode: " + leftMostNode + " | i: " + i + "\n");

                for (int j = 0; j < leavesPerLevel; j++)
                {
                    if (i == n)
                        break;
                    else if (j == 0)
                    {
                        createNode(leaf[i], nodeValue[i], i, height, widthTemp);
                        leftMostTemp = i;
                    }
                    else if (j < leavesPerLevel)
                        createNode(leaf[i], nodeValue[i], i, height, widthTemp += Canvas.GetLeft(leaf[leftMostNode]));
                    i++;
                }
                leftMostNode = leftMostTemp;
                leavesPerLevel *= 2;
                height += 75;
                divide *= 2;
            }
        }
        private async void createNode(Ellipse node, Label value, int index, int height, double width)
        {
            Console.WriteLine("leaf: " + index + " added on " + (width));
            Canvas.SetTop(node, height);
            Canvas.SetLeft(node, width);
            Canvas.SetTop(value, height + 5);
            Canvas.SetLeft(value, width + 10);
            canvasTree.Children.Add(node);
            canvasTree.Children.Add(value);
            await Task.Delay(500);
        }
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
