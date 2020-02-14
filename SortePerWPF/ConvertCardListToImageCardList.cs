using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SortePerWPF
{
    class ConvertCardListToImageCardList : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ConvertCardToImageCard c = new ConvertCardToImageCard();
            List<ImageCard> imgList = new List<ImageCard>(); 
            if (value is List<Card>)
                foreach (Card item in (List<Card>)value)
                {
                    imgList.Add((ImageCard)c.Convert(item, null, null, null));
                }

            return imgList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
