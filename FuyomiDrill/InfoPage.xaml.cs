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
    /// InfoPage.xaml の相互作用ロジック
    /// </summary>
    public partial class InfoPage : Page
    {
        private int level;

        public InfoPage()
        {
            InitializeComponent();
            level = 0;
        }

        public InfoPage(int level)
        {
            InitializeComponent();
            this.level = level;
            kaishi.Text ="レベル" + (level+1).ToString() + "を開始 : Enter";
        }

        private void keyDownHandler(object sender, KeyEventArgs e)
        {
        }
    }
}
