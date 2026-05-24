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

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaktionslogik für ucWindowStyle.xaml
    /// </summary>
    public partial class ucWindowStyle : UserControl
    {
        public ucWindowStyle()
        {
            InitializeComponent();
        }

        public new int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static new readonly DependencyProperty WidthProperty =
            DependencyProperty.Register(nameof(Width), typeof(int), typeof(ucWindowStyle), new PropertyMetadata(null));

        public new int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static new readonly DependencyProperty HeightProperty =
            DependencyProperty.Register(nameof(Height), typeof(int), typeof(ucWindowStyle), new PropertyMetadata(null));

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public static new readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(ucWindowStyle), new PropertyMetadata(Brushes.Gray));

        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static new readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ucWindowStyle), new PropertyMetadata(new Thickness(0.0)));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ucWindowStyle), new PropertyMetadata(null));

    }
}
