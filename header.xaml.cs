using System;
using System.Collections.Generic;
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
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void header(object sender, MouseButtonEventArgs e)
        {

            Window.GetWindow(this).DragMove();//ヘッダーをドラッグしてウィンドウを移動できるようにする
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close(); // アプリを終了（画面を閉じる）
        }

        private void Minisize(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized; // ウィンドウを最小化
        }

        private void Maxsize(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this).WindowState == WindowState.Maximized)
            {
                Window.GetWindow(this).WindowState = WindowState.Normal; // ウィンドウを元のサイズに戻す
            }
            else
            {
                Window.GetWindow(this).WindowState = WindowState.Maximized; // ウィンドウを最大化
            }
        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow クラスのインスタンスを取得
            var mainWindow = Window.GetWindow(this) as MainWindow;
            
                
                // ToggleButton のチェック状態と連動させる
                mainWindow.NavDrawer.IsLeftDrawerOpen = MenuToggleButton.IsChecked ?? false;
           
        }
    }
}
