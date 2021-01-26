using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Assignment1.Converters
{
        public class ByteToImageConverter : IValueConverter
    {
      

 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null)
            {
                Stream stream = new MemoryStream(value as byte[]);
                var imageSource = ImageSource.FromStream(() => stream);

                return imageSource;
            }
            return null;
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
