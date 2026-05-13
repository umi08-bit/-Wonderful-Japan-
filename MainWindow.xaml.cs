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


    }
}