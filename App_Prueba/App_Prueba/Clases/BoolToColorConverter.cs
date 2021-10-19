using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App_Prueba.Clases
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ParamRandom;

            bool.TryParse(value.ToString(), out ParamRandom);

            if (ParamRandom)
                return Color.FromHex("#28B463");
            return Color.FromHex("#FF5733");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}
