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


namespace UI_application_UX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            // ① まずメニューの引き出しを閉じる
            NavDrawer.IsLeftDrawerOpen = false;

            // ② UIの処理が落ち着いてから、ターゲットを画面に引っ張り出す（時間差攻撃！）
            Dispatcher.InvokeAsync(() =>
            {
                TargetArchitecture.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        // 「観光地」ボタンが押された時
        private void MenuSightseeing_Click(object sender, RoutedEventArgs e)
        {
            NavDrawer.IsLeftDrawerOpen = false;

            Dispatcher.InvokeAsync(() =>
            {
                TargetSightseeing.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        // 「植物」ボタンが押された時
        private void MenuPlants_Click(object sender, RoutedEventArgs e)
        {
            NavDrawer.IsLeftDrawerOpen = false;

            Dispatcher.InvokeAsync(() =>
            {
                TargetPlants.BringIntoView();
            }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }


    }
}