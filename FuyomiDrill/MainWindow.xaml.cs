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
        // Templateで定義したStatusBarに文字を表示
        // </summary>
        public void setStatus(string statusContent)
        {
            Label statusLabel = this.GetTemplateChild("statusLabel") as Label;
            statusLabel.Content = statusContent;
        }

        //<summary>
        //window上でのキー操作をハンドル
        //</summary>
        private void keyDownHandler(object sender, KeyEventArgs e)
        {
            //EscキーでStartPageに戻る
            if (e.Key == Key.Escape)
            {
                StartPage sP = new StartPage();
                NavigationService.Navigate(sP);
            }

            Page p = (Page)NavigationService.Content;

            //InfoPageにおけるkeyDown
            if (p.Title == "InfoPage")
            {
                switch (e.Key)
                {
                    case Key.Enter :
                        GamePage gP = new GamePage();
                        NavigationService.Navigate(gP);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
