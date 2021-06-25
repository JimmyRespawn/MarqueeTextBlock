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
using Windows.UI.Xaml.Navigation;

namespace Porject.UserControls
{
    public sealed partial class VideoCard : UserControl
    {
        public VideoCard()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            get => title.Text;
            set
            {
                title.Text = value;
            }
        }

        private void Title_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            title.AnimationInit();
            title._scrollAnimation.Begin();
        }

        private void StackPanel_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                title._scrollAnimation.Stop();
            }
            catch
            {

            }
        }
    }
}
