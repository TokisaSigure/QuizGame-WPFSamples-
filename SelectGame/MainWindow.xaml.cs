using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.SmallBasic.Library;
using System.Diagnostics;

namespace SelectGame
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        #region グローバル変数
        int ans;//解答を挿入するよう変数
        int num=0;//状態遷移用変数
        int quesnum = 0;//問題数格納用変数
        DispatcherTimer dispatcherTimer;
        int testnum=0;
        string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//ドキュメントまでのパス
        string Resource = @"\GitHub\QuizGame-WPFSamples-\Music\";//音声データの場所
        DateTime dt = DateTime.Now;//時間表示のための変数
        int Hour;//便宜的に時間代入用変数を作ってみた
        int Minute;//上に同じく、こっちは分

        #endregion

        //Windowが呼び出されたら呼ばれる、つまりゲーム実行時に呼ばれる
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//ドキュメントまでのパス
            string Resource = @"\GitHub\QuizGame-WPFSamples-\img\";//フォルダ内の画像の場所
            BitmapImage bmImag;//Canvasに画像を表示するために宣言
            Image imag;//Canvasに画像を表示するために宣言、Urlをうけとり、画像精製までの仕事を行うっポイ？
            bmImag = new BitmapImage(new Uri(rootPath + Resource + "window1-1.png"));//画像URL渡し
            imag = new Image();
            imag.Source = bmImag;//画像のURL受け取り
            imag.Width = 400;//画像の横サイズ設定
            imag.Height = 100;//画像の縦サイズ設定
            canvas1.Children.Add(imag);//Canvasに画像を表示
            /*
            // タイマー
            this.dispatcherTimer = new DispatcherTimer();

            // タイマーのスパンは1秒
            this.dispatcherTimer.Interval = new TimeSpan(100000);

            // タイマーが更新されるたびによばれるイベント追加
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            // タイマー動作開始
            this.dispatcherTimer.Start();
            */
        }


        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            testnum++;
            this.textBlock3.Text = testnum+"";
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (num == 0)
            {
                num++;
                quesnum = 1;
                ans = 1;
                this.textBlock1.Visibility = System.Windows.Visibility.Visible;
                this.textBlock1.Text = "第" + quesnum + "問";
            }
            else
            {
                ans = 1;
            }

            Question();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ans = 2;
            Question();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }


        //クイズ表示用関数、クラス化できないか、別ファイル化できないか検討してみると、色々便利かも
        private void Question()
        {
            //ここからクイズ表示用箇所
            if (num > 0)
            {
                switch (num)
                {
                    case 1: this.textBlock2.Text = testClass.get_ques(); num++; break;
                    case 2: if (ans != 1)
                        {
                            this.textBlock2.Text = testClass.get_bad();
                            num = 0;
                            Sound.PlayAndWait(rootPath + Resource + "ぶっぶー1.wav");
                        }
                        else
                        {
                            this.textBlock2.Text = testClass.get_good();
                            num++;
                            quesnum++;
                            Sound.PlayAndWait(rootPath + Resource + "ピンポーン1.wav");
                        }
                        break;
                    default: this.textBlock2.Text = Properties.Resources.stop; this.textBlock1.Text = "第" + quesnum + "問"; break;
                }
            }
            //クイズ処理ここまで
        }

        /*現在時刻を取得*/
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            dt = DateTime.Now;//現在時刻取得
            Hour = dt.Hour;//時間を入力
            Minute = dt.Minute;//分を入力
            this.label2.Content = dt.Hour+"時"+dt.Minute+"分"+dt.Second+"秒";
        }

        /*時間を23時に指定*/
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Hour = 23;
            Minute = 0;
            this.label2.Content = Hour + "時" + Minute + "分";
        }

        /*時間を9時に指定*/
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Hour = 9;
            Minute = 0;
            this.label2.Content = Hour + "時" + Minute + "分";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (Hour > 0 && Hour <= 10)
            {
                this.textBlock2.Text = "おはようございます";
            }
            else if (Hour > 10 && Hour <= 15)
            {
                this.textBlock2.Text = "おは・・・いえ、今何時だと思っているんですか？";
            }
            else if (Hour > 15)
            {
                this.textBlock2.Text = "もう半日以上過ぎてますよ、何をしているんですか。";
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            #region ニコニコが開くよ
            //Process process = Process.Start(@"http://www.nicovideo.jp/");
            #endregion

            Process process = Process.Start(@"C:\Users\1223077\Desktop\AHS\VOICEROID+\yukari\VOICEROID.exe");

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("shutdown.exe","/r");
        }
    }
}
