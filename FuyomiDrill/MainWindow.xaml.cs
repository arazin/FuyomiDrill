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
using System.Windows.Threading;
using System.IO;

namespace FuyomiDrill
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {

        /// <summary>
        /// 経過時間計測用
        /// </summary>
        private DispatcherTimer timer;
        /// <summary>
        /// 経過時間
        /// </summary>
        private TimeSpan resultTime;
        /// <summary>
        /// イベントトリガーインターバル
        /// </summary>
        private TimeSpan interval;

        /// <summary>
        /// 時間計測のイベントハンドラ。intervalの間隔で呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // 経過時間を加算
            resultTime = resultTime.Add(interval);
            // 経過時間を表示
            this.setStatus(resultTime.TotalSeconds.ToString("f1"));
        }


        public MainWindow()
        {
            InitializeComponent();


            // 経過時間計測用
            interval = new TimeSpan(0, 0, 0, 0, 100);
            resultTime = TimeSpan.Zero;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = interval;
        }
        
        /// <summary>
        /// タイマー起動
        /// </summary>
        public void StartTimer(){
            resultTime = TimeSpan.Zero;
            this.setStatus(resultTime.TotalSeconds.ToString("f1"));
            timer.Start();
        }

        /// <summary>
        /// タイマー停止
        /// </summary>
        /// <returns>経過時間</returns>
        public TimeSpan StopTimer()
        {
            timer.Stop();
            return resultTime;

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
            if (e.Key == Key.Escape)
            {
                if (p.Title == "GamePage")
                {
                    this.StopTimer();
                }
                this.setStatus("");
                StartPage sP = new StartPage();
                NavigationService.Navigate(sP);

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
