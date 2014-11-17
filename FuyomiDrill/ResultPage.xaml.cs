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
    /// ResultPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(TimeSpan resultTime, int missCount)
        {
            InitializeComponent();
            levelResultTextBlock.Text = "level" + (((int)Application.Current.Properties["level"]) + 1).ToString();
            missTextBlock.Text = missCount.ToString();
            resultTimeTextBlock.Text = resultTime.ToString(@"ss\.f");
        }
    }
}
