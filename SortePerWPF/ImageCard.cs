using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SortePerWPF
{
    public class ImageCard : Image
    {
        public Card card;
        public ImageCard(Card card)
        {
            this.Source = new BitmapImage(new Uri(@"Assets/" + card.CardValue + ".png", UriKind.Relative));
            this.card = card;
        }

    }
}
