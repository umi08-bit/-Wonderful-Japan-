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
    /// card.xaml の相互作用ロジック
    /// </summary>
    public partial class card : UserControl
    {
        public event RoutedEventHandler MapOpenRequested;
        public card()
        {
            InitializeComponent();
        }
        public string MapUrl { get; set; } = "https://www.google.com/maps";
        public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(card), new PropertyMetadata("デフォルトタイトル"));
        public static readonly DependencyProperty imageParhProperty =
        DependencyProperty.Register("imageParh", typeof(string), typeof(card), new PropertyMetadata("/images/タコ.png"));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("Description", typeof(string), typeof(card), new PropertyMetadata("デフォルト説明文"));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public string imageParh
        {
            get { return (string)GetValue(imageParhProperty); }
            set { SetValue(imageParhProperty, value); }
        }

        private void OpenMap_Click(object sender, RoutedEventArgs e)
        {
            MapOpenRequested?.Invoke(this, e);
        }

    }
}
