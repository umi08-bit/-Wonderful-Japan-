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


    }
}