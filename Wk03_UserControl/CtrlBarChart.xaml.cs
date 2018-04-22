using System;
using System.Collections.Generic;
using System.IO;
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

namespace Wk03_UserControl
{
    /// <summary>
    /// Interaction logic for CtrlBarGraph.xaml
    /// </summary>
    public partial class CtrlBarGraph : UserControl
    {
        string filename = @"C:\Users\e_syl\Google Drive\COMP212\comp212-w18\Wk03_UserControl\barChart.txt";
        List<Int32> data = new List<int>();

        public CtrlBarGraph()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            TextReader reader = new StreamReader(filename);
            string input;
            input = reader.ReadLine();
            while (input!=null)
            {
                int aData = Int32.Parse(input);
                data.Add(aData);
                input = reader.ReadLine();
            }
            reader.Close();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Pen pen = new Pen(Brushes.Blue,1);
            double HorizontalInterval = this.ActualWidth / data.Count;
            var range = data.Max();
            double VerticalScaling = this.ActualHeight / range;

            for (int i = 0; i < data.Count; i++)
            {
                drawingContext.DrawRectangle(Brushes.BlueViolet, pen, new Rect(i * HorizontalInterval, (this.ActualHeight- (data[i] * VerticalScaling)), HorizontalInterval, data[i]*VerticalScaling));
            }
        }
    }
}
