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
using System.IO;

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
            Page p = (Page)NavigationService.Content;

            //EscキーでStartPageに戻る
            // TODO:できればGamePageでもesc機能させたい
            if (p.Title != "GamePage")
            {
                if (e.Key == Key.Escape)
                {
                    StartPage sP = new StartPage();
                    NavigationService.Navigate(sP);
                }
            }


            //InfoPageにおけるkeyDown
            if (p.Title == "InfoPage")
            {
                Page nextP = null;
                switch (e.Key)
                {
                    case Key.Enter:
                        try
                        {
                            nextP = new GamePage();
                        }
                        catch (FileNotFoundException ex)
                        {
                            this.setStatus(ex.Message);
                            nextP = new StartPage();

                        }
                        NavigationService.Navigate(nextP);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
