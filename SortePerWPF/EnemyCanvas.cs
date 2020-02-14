using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SortePerWPF
{
    public class EnemyCanvas : Canvas
    {
         public List<ImageCard> ImageCards
        {
            get { return (List<ImageCard>)GetValue(ImageCardsProperty); }
            set { SetValue(ImageCardsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageCards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCardsProperty =
            DependencyProperty.Register("ImageCards", typeof(List<ImageCard>), typeof(EnemyCanvas), new PropertyMetadata(null, new PropertyChangedCallback(ImageCardsChanged)));


        private static void ImageCardsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            EnemyCanvas control = (EnemyCanvas)o;
            if (control != null)
                control.ImageCardsHaveChanged();
        }

        public EnemyCanvas()
        {
        }

        private void ImageCardsHaveChanged()
        {
            Children.Clear();
            int offset = 0;
            foreach(ImageCard img in ImageCards)
            {
                img.Height = 200;
                img.Width = 150;
                img.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                flipTrans.ScaleY = -1;
                img.RenderTransform = flipTrans;

                this.Children.Add(img);
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, -250 + offset);
                offset += 85;
                img.MouseEnter += MouseEntered;
                img.MouseLeave += MouseLeft;
            }
        }

        void MouseEntered(object sender, MouseEventArgs e)
        {
            Image control = (ImageCard)sender;
            if (control == null)
                return;


            Canvas.SetTop(control, 30);
        }

        void MouseLeft(object sender, MouseEventArgs e)
        {
            Image control = (ImageCard)sender;
            if (control == null)
                return;


            Canvas.SetTop(control, 0);
        }
    }
}
