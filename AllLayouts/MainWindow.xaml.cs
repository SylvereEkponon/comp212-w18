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

namespace AllLayouts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;

            switch (fe.Name)
            {
                case "canvasBtn":
                    frmContent.Content = new PageCanvas();
                    break;
                case "dockPanelBtn":
                    frmContent.Content = new PageDock();
                    break;
                case "stackPanelBtn":
                    frmContent.Content = new PageStackPanel();
                    break;
                case "wrapBtn":
                    frmContent.Content = new PageWrap();
                    break;
                case "gridBtn":
                    frmContent.Content = new PageGrid();
                    break;
                case "uniFormGridBtn":
                    frmContent.Content = new PageUniGrid();
                    break;
            }
        }
    }
}
