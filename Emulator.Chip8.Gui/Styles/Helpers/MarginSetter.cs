using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;

namespace Emulator.Chip8.Gui.Styles.Helpers
{
    public class MarginSetter
    {
        public static DependencyProperty HorizontalMarginProperty = DependencyProperty.RegisterAttached("HorizontalMargin", typeof(int), typeof(MarginSetter), new PropertyMetadata(default(int), MarginChangedCallback));

        public static DependencyProperty VerticalMarginProperty = DependencyProperty.RegisterAttached("VerticalMargin", typeof(int), typeof(MarginSetter), new PropertyMetadata(default(int), MarginChangedCallback));

        public static int GetHorizontalMargin(DependencyObject obj)
        {
            return (int)obj.GetValue(HorizontalMarginProperty);
        }

        public static void SetHorizontalMargin(DependencyObject obj, int margin)
        {
            obj.SetValue(HorizontalMarginProperty, margin);
        }

        public static int GetVerticalMargin(DependencyObject obj)
        {
            return (int)obj.GetValue(VerticalMarginProperty);
        }

        public static void SetVerticalMargin(DependencyObject obj, int margin)
        {
            obj.SetValue(VerticalMarginProperty, margin);
        }

        public static void MarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null)
            {
                return;
            }

            panel.Loaded += new RoutedEventHandler(PanelLoaded);
        }

        static void PanelLoaded(object sender, RoutedEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null || panel.Children.Count < 2)
            {
                return;
            }

            var horizontalMargin = GetHorizontalMargin(panel);
            if (horizontalMargin > 0)
            {
                SetHorizontalMargin(panel, horizontalMargin);
                return;
            }

            var verticalMargin = GetVerticalMargin(panel);
            if (verticalMargin > 0)
            {
                SetVerticalMargin(panel, verticalMargin);
                return;
            }
        }

        private static void SetHorizontalMargin(Panel panel, int margin)
        {
            if (panel.Children[0] is FrameworkElement firstChild)
            {
                firstChild.Margin = new Thickness(0, 0, margin / 2.0, 0);
            }

            if (panel.Children[panel.Children.Count - 1] is FrameworkElement lastChild)
            {
                lastChild.Margin = new Thickness(margin / 2.0, 0, 0, 0);
            }

            for (var i = 1; i < panel.Children.Count - 2; i++)
            {
                if (panel.Children[i] is FrameworkElement child)
                {
                    child.Margin = new Thickness(margin / 2.0, 0, margin / 2.0, 0);
                }
            }
        }

        private static void SetVerticalMargin(Panel panel, int margin)
        {
            if (panel.Children[0] is FrameworkElement firstChild)
            {
                firstChild.Margin = new Thickness(0, 0, 0, margin / 2.0);
            }

            if (panel.Children[panel.Children.Count - 1] is FrameworkElement lastChild)
            {
                lastChild.Margin = new Thickness(0, margin / 2.0, 0, 0);
            }

            for (var i = 1; i < panel.Children.Count - 2; i++)
            {
                if (panel.Children[i] is FrameworkElement child)
                {
                    child.Margin = new Thickness(0, margin / 2.0, 0, margin / 2.0);
                }
            }
        }
    }
}