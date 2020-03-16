using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Example_Node_Size_Changed
{
    public class Gripper : ContentControl
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
            "Target", typeof(FrameworkElement), typeof(Gripper), new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement Target
        {
            get => (FrameworkElement) GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        
        private Thumb _resizeGrip;
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Setup Thumbs
            _resizeGrip = new Thumb
            {
                Width = 18, 
                Height = 18, 
                Background = Brushes.Blue,
            };

            _resizeGrip.DragDelta += OnGripDelta;
            Content = _resizeGrip;
        }

        private void OnGripDelta(object sender, DragDeltaEventArgs e)
        {
            if (_resizeGrip is null)
                return;

            var frameworkElement = Target;
            
            var w = frameworkElement.Width;
            var h = frameworkElement.Height;
            if (w.Equals(double.NaN))
                w = frameworkElement.DesiredSize.Width;
            if (h.Equals(double.NaN))
                h = frameworkElement.DesiredSize.Height;

            w += e.HorizontalChange;
            h += e.VerticalChange;

            // clamp
            w = Math.Max(_resizeGrip.Width, w);
            h = Math.Max(_resizeGrip.Height, h);
            w = Math.Max(frameworkElement.MinWidth, w);
            h = Math.Max(frameworkElement.MinHeight, h);
            w = Math.Min(frameworkElement.MaxWidth, w);
            h = Math.Min(frameworkElement.MaxHeight, h);

            frameworkElement.SetValue(WidthProperty,w);
            frameworkElement.SetValue(HeightProperty,h);
        }
    }
}