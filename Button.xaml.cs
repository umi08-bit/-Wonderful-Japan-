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
    /// Button.xaml の相互作用ロジック
    /// </summary>
    
    public partial class Button : UserControl
    {
        public static readonly DependencyProperty ButtonProperty =
        DependencyProperty.Register("Button", typeof(string), typeof(Button), new PropertyMetadata("デフォルトタイトル"));
        public event RoutedEventHandler Click;
        public Button()
        {
            InitializeComponent();
        }
        private void InnerButton_Click(object sender, RoutedEventArgs e)
        {
            // ③ 外側（MainWindow）に向けて「ボタンが押されたぞ！」と信号を飛ばす
            Click?.Invoke(this, e);
        }
        public string Button_Text
        {
            get { return (string)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }
    }
}
