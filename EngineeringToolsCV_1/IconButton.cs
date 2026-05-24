using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EngineeringToolsCV_1
{
    public class IconButton : Button
    {
        private static CornerRadius _defaultCornerRadius = new CornerRadius(10.0);

        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton),
               new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register(nameof(PathData), typeof(Geometry),
                   typeof(IconButton), new PropertyMetadata(Geometry.Empty));

        public Geometry PathData
        {
            get { return (Geometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string),
                            typeof(IconButton), new PropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation),
                                    typeof(Orientation), typeof(IconButton), new PropertyMetadata(default(Orientation)));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty TextVisibilityProperty = DependencyProperty.Register(nameof(TextVisibility),
                                         typeof(Visibility), typeof(IconButton), new PropertyMetadata(default(Visibility)));

        public Visibility TextVisibility
        {
            get { return (Visibility)GetValue(TextVisibilityProperty); }
            set { SetValue(TextVisibilityProperty, value); }
        }

        public static readonly DependencyProperty IconVisibilityProperty = DependencyProperty.Register(nameof(IconVisibility),
                           typeof(Visibility), typeof(IconButton), new PropertyMetadata(default(Visibility)));
		public Brush TextColor
		{
			get { return (Brush)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register(nameof(TextColorProperty),
								 typeof(Brush), typeof(IconButton), new PropertyMetadata(Brushes.Black));

		public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }

       
        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

		  public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register(nameof(IconColor),
								  typeof(Brush), typeof(IconButton), new PropertyMetadata(Brushes.AliceBlue));

	 	  public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(IconButton), new PropertyMetadata(_defaultCornerRadius));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static DependencyProperty IconWidthProperty =
						DependencyProperty.Register(nameof(IconWidth), typeof(double), typeof(IconButton), new PropertyMetadata(16.6));


		public double IconHeight
		{
			get { return (double)GetValue(IconHeightProperty); }
			set { SetValue(IconHeightProperty, value); }
		}

		public static DependencyProperty IconHeightProperty =
						DependencyProperty.Register(nameof(IconHeight), typeof(double), typeof(IconButton), new PropertyMetadata(16.6));
	}
}
