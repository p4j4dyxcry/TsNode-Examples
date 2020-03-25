using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using TsNode.Controls;
using TsNode.Interface;

namespace Example_Customize_ScrollViewer
{
    public class RaiseScaleBehavior : Behavior<UIElement>
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
            "Target", typeof(InfiniteScrollViewer), typeof(RaiseScaleBehavior), new PropertyMetadata(default(InfiniteScrollViewer)));

        public InfiniteScrollViewer Target
        {
            get { return (InfiniteScrollViewer) GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
        
        protected override void OnAttached()
        {
            if (AssociatedObject is TextBox textBox)
            {
                textBox.KeyDown += (s, e) =>
                {
                    if (double.TryParse(textBox.Text, out var d))
                    {
                        Target?.Scale(d, Target.ActualWidth / 2d, Target.ActualHeight / 2d);
                        textBox.SetCurrentValue(TextBox.TextProperty,(d / 100).ToString());
                    }
                };
            }
            
            if (AssociatedObject is Slider slider)
            {
                void raise_scale(object s , MouseEventArgs e)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        Target?.Scale(slider.Value , Target.ActualWidth / 2d, Target.ActualHeight / 2d);
                    }
                }

                slider.MouseDown += raise_scale;
                slider.MouseMove += raise_scale;
            }
            

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }

    public static class TransformHolderExtensions
    {
        public static Point TransformPoint(this InfiniteScrollViewer self, double x, double y)
        {
            return new Point(
                (x - self.TranslateMatrix.X) / self.ScaleMatrix.ScaleX,
                (y - self.TranslateMatrix.Y) / self.ScaleMatrix.ScaleY);
        }

        public static void Scale(this InfiniteScrollViewer self, double scale, double centerX, double centerY)
        {
            var d0 = self.TransformPoint(centerX, centerY);

            self.ScaleMatrix.ScaleX = scale;
            self.ScaleMatrix.ScaleY = scale;

            var d1 = self.TransformPoint(centerX, centerY);

            var diff = d1 - d0;

            self.TranslateMatrix.X += diff.X * scale;
            self.TranslateMatrix.Y += diff.Y * scale;
        }
    }
}