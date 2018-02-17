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
            buildTree(new int[] { 4, 10, 3, 5, 1 });
            history = hs.getHeap(new int[] { 4, 10, 3, 5, 1 });
            buttonRun.IsEnabled = false;
            buttonNext.IsEnabled = true;
            buttonClear.IsEnabled = true;
        }
        private void buildTree(int[] input)
        {
            Ellipse[] leaves = new Ellipse[input.Length];

        }
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
