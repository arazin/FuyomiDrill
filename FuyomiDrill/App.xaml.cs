using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FuyomiDrill
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        //<summary>
        //windowを参照するためのメソッド
        //<summary>
        public static Window GetWindow(string name)
        {
            Window targetWindow = null;

            WindowCollection appWindows = Application.Current.Windows;
            foreach (Window win in appWindows)
            {
                if (win.Name == name)
                {
                    targetWindow = win;
                    break;
                }
            }
            return targetWindow;
        }
    }
}
