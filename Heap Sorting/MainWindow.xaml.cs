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
            buildTree(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, });
            history = hs.getHeap(new int[] { 4, 10, 3, 5, 1 });
            buttonRun.IsEnabled = false;
            buttonNext.IsEnabled = true;
            buttonClear.IsEnabled = true;
        }
        private void buildTree(int[] input)
        {
            int n = input.Length, height = 10, leavesPerLevel = 1, parent = 0, leftMostTemp = 0;
            Line[] connectLeaf = new Line[n - 1];
            Ellipse[] leaf = new Ellipse[n];
            Label[] nodeValue = new Label[n];
            double divide = 2, widthTemp = 0, widthTempPrevious = 0;

            int[,] parents = new int[n, 3];

            for (int i = 0; i < n; i++)
            {
                leaf[i] = new Ellipse { Width = 40, Height = 40, Fill = Brushes.White, Stroke = Brushes.Black, StrokeThickness = 2 };
                nodeValue[i] = new Label() { Content = input[i] };
                if (i < n - 1)
                    connectLeaf[i] = new Line { StrokeThickness = 2, Stroke = Brushes.Black };
            }
            //create root
            createNode(leaf[0], nodeValue[0], 0, height, widthTemp = (canvasTree.ActualWidth - 25) / 2);
            height += 75; leavesPerLevel *= 2; divide *= 2;
            widthTempPrevious = widthTemp;
            widthTemp /= 2;

            for (int i = 1; i < n; i++)
            {                
                Console.WriteLine("\nParent: " + parent + " | Width Temp: " +widthTemp + " | Width Temp Previous Parent: " + widthTempPrevious);
leftMostTemp = leavesPerLevel - 1;
                //PRINT CHILDREN
                //print left
                if (i < n && i == leftMostTemp)
                {
                    Console.WriteLine("True");
                    createNode(leaf[i], nodeValue[i], i, height, widthTemp);
                    connectNode(leaf[parent], leaf[i], connectLeaf[i-1]);
                }
                else
                {
                    createNode(leaf[i], nodeValue[i], i, height, widthTemp += widthTempPrevious);
                    connectNode(leaf[parent], leaf[i], connectLeaf[i - 1]);
                }
                //print right
                if (i + 1 < n)
                {
                    createNode(leaf[i + 1], nodeValue[i + 1], i + 1, height, widthTemp += widthTempPrevious);
                    connectNode(leaf[parent], leaf[i+1], connectLeaf[i]);
                    i++;
                }
                parent++;
                
                Console.WriteLine("Left most: " + leftMostTemp);
                if (leavesPerLevel == parent + 1)
                {
                    leavesPerLevel *= 2; height += 75; divide *= 2;
                    widthTempPrevious = Canvas.GetLeft(leaf[leftMostTemp]);
                    widthTemp = Canvas.GetLeft(leaf[leftMostTemp]) / 2;
                }
            }
        }
        private void createNode(Ellipse node, Label value, int index, int height, double width)
        {
            Console.WriteLine("leaf: " + index + " added on " + (width));
            Canvas.SetTop(node, height);
            Canvas.SetLeft(node, width);
            Canvas.SetTop(value, height + 5);
            Canvas.SetLeft(value, width + 10);
            canvasTree.Children.Add(node);
            canvasTree.Children.Add(value);
        }
        private void connectNode(Ellipse parent, Ellipse child, Line connect)
        {
            connect.X1 = Canvas.GetLeft(parent) + 20;
            connect.Y1 = Canvas.GetTop(parent) + 39;
            connect.X2 = Canvas.GetLeft(child) + 20;
            connect.Y2 = Canvas.GetTop(child) + 1;
            canvasTree.Children.Add(connect);
        }
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
