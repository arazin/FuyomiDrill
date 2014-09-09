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

namespace FuyomiDrill
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // <summary>
        // Templateで定義したStatusBar
        // </summary>
        public void setStatus(string statusContent)
        {
            Label statusLabel = this.GetTemplateChild("statusLabel") as Label;
            statusLabel.Content = statusContent;
        }
    }
}
