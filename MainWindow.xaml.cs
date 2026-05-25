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
using static MaterialDesignThemes.Wpf.Theme;
using System.Windows.Threading;



namespace UI_application_UX
{
    
    public partial class MainWindow : Window
    {
        private List<string> _imagePaths = new List<string>
        {
            "/images/arasi.png",
            "/images/fuji.png",
            "/images/kiyomizu.png",
            "/images/kin.png",
            "/images/duogo.png",
            "/images/ituku.png",
            "/images/same.png",
            "/images/oosaka.png",
            "/images/yuni.png",
            "/images/tomita.png",
            "/images/himezi.png"

        };

        private int _currentImageIndex = 0; // 今何枚目を表示しているかのカウンター
        private DispatcherTimer _timer;     // 時間を測るタイマー本体

        public MainWindow()
        {
            InitializeComponent();
            StartSlideshow();
        }

        // スライドショーの準備と開始
        private void StartSlideshow()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(3); // 切り替え時間設定
            _timer.Tick += Timer_Tick;                 // 時間が来たら Timer_Tick を呼ぶ
            _timer.Start();                            // タイマー起動
        }

        // 設定した時間が来るたびに自動で呼ばれるメソッド
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 次の画像へインデックスを進める
            _currentImageIndex++;

            // もし最後の画像を過ぎたら、最初（0番目）に戻してループさせる
            if (_currentImageIndex >= _imagePaths.Count)
            {
                _currentImageIndex = 0;
            }

            // 画像を切り替える
            TopImage.Source = new BitmapImage(new Uri(_imagePaths[_currentImageIndex], UriKind.Relative));
        }
  


        //マウスホイールを横スクロールに変換するイベントハンドラー
        private void HorizontalScroll(object sender, MouseWheelEventArgs e)
        {

            ScrollViewer scrollViewer = sender as ScrollViewer;

            if (scrollViewer != null)
            {
                // マウスホイールの回転方向に応じて、横スクロールを行う
                if (e.Delta > 0)
                {
                    scrollViewer.LineLeft();
                    scrollViewer.LineLeft();
                }
                else
                {
                    scrollViewer.LineRight();
                    scrollViewer.LineRight();

                }

                e.Handled = true;

            }



        }
        private void Card_MapOpenRequested(object sender, RoutedEventArgs e)
        {
            // 信号を送ってきたパーツをcardとして認識する
            var clickedCard = sender as card;

            if (clickedCard != null)
            {
                // そのカードが持っている固有のURLを抜き出す
                string targetUrl = clickedCard.MapUrl;

                // モニターにそのURLを表示
                MapWebView.Source = new Uri(targetUrl);

                // ダイアログを展開
                MainDialogHost.IsOpen = true;
            }
        }
        // 「建築物」ボタンが押された時
        private void MenuArchitecture_Click(object sender, RoutedEventArgs e)
        {
            // まずメニューの引き出しを閉じる
            NavDrawer.IsLeftDrawerOpen = false;
            HeaderUI.ResetMenuButton();//ハンバーガーボタンをリセットする

            // UIの処理が落ち着いてから、ターゲットを画面に引っ張り出す
            Dispatcher.InvokeAsync(() =>
            {
                TargetArchitecture.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        // 「観光地」ボタンが押された時
        private void MenuSightseeing_Click(object sender, RoutedEventArgs e)
        {
            NavDrawer.IsLeftDrawerOpen = false;
            HeaderUI.ResetMenuButton(); //ハンバーガーボタンをリセットする
            Dispatcher.InvokeAsync(() =>
            {
                TargetSightseeing.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        // 「植物」ボタンが押された時
        private void MenuPlants_Click(object sender, RoutedEventArgs e)
        {
            NavDrawer.IsLeftDrawerOpen = false;
            HeaderUI.ResetMenuButton();//ハンバーガーボタンをリセットする
            Dispatcher.InvokeAsync(() =>
            {
                TargetPlants.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }


    }
}