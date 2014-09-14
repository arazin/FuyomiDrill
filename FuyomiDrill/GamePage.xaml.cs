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
using FuyomiDrillCore;
using System.IO;

namespace FuyomiDrill
{
    /// <summary>
    /// GamePage.xaml の相互作用ロジック
    /// </summary>
    public partial class GamePage : Page
    {

        private int level;
        private FuyomiGame game;
        private MainWindow mainWindow;

        public GamePage()
        {
            InitializeComponent();

            mainWindow = App.GetWindow("NavWin") as MainWindow;

            game = new FuyomiGame(((int)Application.Current.Properties["level"]) + 1);
            this.qTextBox.Text = game.GameStart();
            level = (int)Application.Current.Properties["level"];
        }

        private void keyClick(object sender, RoutedEventArgs e)
        {
            Button keyButton = null;
            string ans = "";
            string nextQuestion = "";

            if (sender is Button)
            {
                keyButton = (Button)sender;
                ans = keyButton.Name;
            }

            nextQuestion = game.IsCorrect(ans);

            if (nextQuestion == "false")
            {
                mainWindow.setStatus("False.");
            }
            else if (nextQuestion == "end")
            {
                // TODO:ResultPageへ遷移
                mainWindow.setStatus("Finish!");
                Page p = new StartPage();
                NavigationService.Navigate(p);
            }
            else
            {
                mainWindow.setStatus("Correct.");
                this.qTextBox.Text = nextQuestion;
            }

        }




    }
}
