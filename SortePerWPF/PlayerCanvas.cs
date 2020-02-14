using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SortePerWPF
{
    public class PlayerCanvas : Canvas
    {


        public List<ImageCard> ImageCards
        {
            get { return (List<ImageCard>)GetValue(ImageCardsProperty); }
            set { SetValue(ImageCardsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageCards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCardsProperty =
            DependencyProperty.Register("ImageCards", typeof(List<ImageCard>), typeof(PlayerCanvas), new PropertyMetadata(null, new PropertyChangedCallback(ImageCardsChanged)));



        private static void ImageCardsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PlayerCanvas control = (PlayerCanvas)o;
            if (control != null)
                control.ImageCardsHaveChanged();
        }

        public PlayerCanvas()
        {
        }

        private void ImageCardsHaveChanged()
        {

            Children.Clear();
            int offset = 0;
            foreach (ImageCard img in ImageCards)
            {
                img.Height = 200;
                img.Width = 150;

                this.Children.Add(img);
                Canvas.SetTop(img, 150);
                Canvas.SetLeft(img, -250 + offset);
                offset += 85;

                img.MouseEnter += MouseEntered;
                img.MouseLeave += MouseLeft;
                img.MouseDown += MouseClicked;
            }
        }

        void MouseEntered(object sender, MouseEventArgs e)
        {
            Image control = (ImageCard)sender;
            if (control == null)
                return;


            Canvas.SetTop(control, 120);
        }

        void MouseLeft(object sender, MouseEventArgs e)
        {
            Image control = (ImageCard)sender;
            if (control == null)
                return;


            Canvas.SetTop(control, 150);
        }

        void MouseClicked(object sender, MouseEventArgs e)
        {
            Image control = (ImageCard)sender;
            if (control == null)
                return;
            Canvas.SetTop(control, 120);
            control.MouseLeave -= MouseLeft;
            control.MouseUp += SortePerGameController.Instance.MatchCards;        
            
        }

        
    }
}
