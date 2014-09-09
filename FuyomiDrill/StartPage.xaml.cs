﻿using System;
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
    /// StartPage.xaml の相互作用ロジック
    /// </summary>
    public partial class StartPage : Page
    {
        private InfoPage iP;
        public StartPage()
        {
            InitializeComponent();
        }

        private void Level_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = App.GetWindow("NavWin") as MainWindow;
            Button tmp = e.OriginalSource as Button;
            win.setStatus(tmp.Name);

            Button senderButton = sender as Button;

            if (senderButton == null)
                return;
            else if (senderButton.Name == "level1")
                iP = new InfoPage(0);
            else if (senderButton.Name == "level2")
                iP = new InfoPage(1);
            else if (senderButton.Name == "level3")
                iP = new InfoPage(2);
            else 
                return;

            NavigationService.Navigate(iP);
        }


    }
}
