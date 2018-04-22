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

namespace Wk03_UserControl
{
    /// <summary>
    /// Interaction logic for CtrlLineGraph.xaml
    /// </summary>
    public partial class CtrlLineGraph : UserControl
    {
        Point[] points;

        public CtrlLineGraph()
        {
            InitializeComponent();
            InitPoints();
        }

        void InitPoints()
        {
            double xOffset = 200, yOffset = 250, xScale = 50, yScale = -100;
            points = new Point[13];
            int i = 0;
            for (double x = 3; x >= -3; x-=0.5)
            {
                double y = x * x * 0.25;
                points[i++] = new Point(x * xScale + xOffset, y * yScale + yOffset);
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Pen pen = new Pen(Brushes.Blue, 3.5);
            for (int i = 1; i < points.Length; i++)
            {
                drawingContext.DrawLine(pen, points[i - 1], points[i]);
            }

            //mouth
            drawingContext.DrawEllipse(Brushes.Red, pen, new Point(200, 200), 40, 20);

            //rectangle
            drawingContext.DrawRectangle(Brushes.Green, pen, new Rect(120, 80, 60, 25));
            drawingContext.DrawRectangle(Brushes.Green, pen, new Rect(220, 80, 60, 25));
        }
    }
}
