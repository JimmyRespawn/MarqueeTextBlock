using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Porject
{
    public sealed partial class ScrollingText : UserControl
    {
        public string Text
        {
            get => TitleBlock.Text;
            set
            {
                TitleBlock.Text = value;
            }
        }

        public ScrollingText()
        {
            this.InitializeComponent();
        }

        public Storyboard _scrollAnimation;
        private void ScrollViewer_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            AnimationInit();
            _scrollAnimation.Begin();
        }

        private void ScrollViewer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _scrollAnimation.Stop();
        }
        public void AnimationInit()
        {
            _scrollAnimation = new Storyboard();
            var animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromSeconds(5);
            animation.RepeatBehavior = new RepeatBehavior(1);
            animation.From = 0;
            // Here you need to calculate based on the number of spaces and the current FontSize
            //animation.To = -((TitleBlock.ActualWidth / 2) - 128);
            animation.To = TitleSV.ActualWidth - TitleBlock.ActualWidth;
            Storyboard.SetTarget(animation, TitleBlock);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
            if (animation.To < 0)
                _scrollAnimation.Children.Add(animation);
        }
    }
}
