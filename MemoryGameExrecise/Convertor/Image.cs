
using MemoryGameExrecise.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MemoryGameExrecise.Convertor
{
    public class Image : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Card card = (Card)value;

            if (card.UserMatched)
                return card.SrcAfterClick;
            return card.SrcStart;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
