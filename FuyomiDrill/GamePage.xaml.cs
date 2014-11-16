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
using FuyomiDrillCore;
using System.IO;
using System.Threading;
using System.Windows.Media.Animation;

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
        private BitmapImage correctImage;
        private BitmapImage falseImage;
        private BitmapImage clearImage;
        private List<Button> keyList;
        private DispatcherTimer timer;
        private TimeSpan resultTime;
        private TimeSpan interval;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            resultTime = resultTime.Add(interval);
            mainWindow.setStatus(resultTime.ToString(@"mm\:ss\.f"));
        }

        public GamePage()
        {
            InitializeComponent();

            keyList = new List<Button>() { C, Cs, D, Ds, E, F, Fs, G, Gs, A, As, B };

            mainWindow = App.GetWindow("NavWin") as MainWindow;

            correctImage = new BitmapImage(new Uri(@"..\..\Correct.png",UriKind.Relative));
            falseImage = new BitmapImage(new Uri(@"..\..\False.png", UriKind.Relative));
            clearImage = new BitmapImage(new Uri(@"..\..\Clear.png",UriKind.Relative));

            // ゲームロジック
            game = new FuyomiGame(((int)Application.Current.Properties["level"]) + 1);
            this.qTextBox.Text = game.GameStart();
            level = (int)Application.Current.Properties["level"];

            // TODO:タイマーをmainwindowへ移行する
            // 問題開始からの経過時間を測る
            interval = new TimeSpan(0, 0, 0, 0, 100);
            resultTime = TimeSpan.Zero;

            mainWindow.setStatus(resultTime.ToString(@"mm\:ss"));

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = interval;
            timer.Start();
        }

        //private void invalidateButton()
        //{
        //    foreach (Button key in keyList)
        //    {
        //        key.IsEnabled = false;
        //    }
        //}

        //private void validateButton()
        //{
        //    foreach (Button key in keyList)
        //    {
        //        key.IsEnabled = true;
        //    }
        //}


        private void keyClick(object sender, RoutedEventArgs e)
        {
            string ans = "";
            string nextQuestion = "";
            Button keyButton = null;
            if (sender is Button)
            {
                keyButton = (Button)sender;
                ans = keyButton.Name;
            }

            DiscreteObjectKeyFrame setImageFrame = new DiscreteObjectKeyFrame();
            DiscreteObjectKeyFrame clearImageFrame = new DiscreteObjectKeyFrame();
            DiscreteObjectKeyFrame setQuestionFrame = new DiscreteObjectKeyFrame();
            setImageFrame.KeyTime = new TimeSpan(0, 0, 0, 0);
            clearImageFrame.KeyTime = new TimeSpan(0, 0, 0, 0, 700);
            clearImageFrame.Value = clearImage;
            setQuestionFrame.KeyTime = new TimeSpan(0, 0, 0, 0, 700);

            nextQuestion = game.IsCorrect(ans);
            if (nextQuestion == "false")
            {
                setImageFrame.Value = falseImage;
                mainWindow.setStatus("False.");
                setQuestionFrame.Value = qTextBox.Text;
            }
            else if (nextQuestion == "end")
            {

                timer.Stop();
                mainWindow.setStatus("Finish!");
                Page p = new ResultPage(resultTime);
                NavigationService.Navigate(p);
            }
            else
            {
                setImageFrame.Value = correctImage;
                //rightOrWrongImage.Source = correctImage;
                mainWindow.setStatus("Correct.");
                this.qTextBox.Text = nextQuestion;
                //setQuestionFrame.Value = nextQuestion;
            }
            ObjectAnimationUsingKeyFrames rightOrWrongAnimation = new ObjectAnimationUsingKeyFrames();
            rightOrWrongAnimation.BeginTime = new TimeSpan(0,0,0,0);
            rightOrWrongAnimation.KeyFrames.Add(setImageFrame);
            rightOrWrongAnimation.KeyFrames.Add(clearImageFrame);

            ObjectAnimationUsingKeyFrames questionAnimation = new ObjectAnimationUsingKeyFrames();
            questionAnimation.BeginTime = new TimeSpan(0, 0, 0, 0);
            questionAnimation.KeyFrames.Add(setQuestionFrame);

            Storyboard gameStoryboard = new Storyboard();
            gameStoryboard.Children.Add(rightOrWrongAnimation);
            Storyboard.SetTargetName(rightOrWrongAnimation, rightOrWrongImage.Name);
            Storyboard.SetTargetProperty(rightOrWrongAnimation, new PropertyPath(Image.SourceProperty));

            //gameStoryboard.Children.Add(questionAnimation);
            //Storyboard.SetTargetName(questionAnimation, qTextBox.Name);
            //Storyboard.SetTargetProperty(questionAnimation,new PropertyPath(TextBlock.TextProperty));

            gameStoryboard.Begin(this);
        }




    }
}
