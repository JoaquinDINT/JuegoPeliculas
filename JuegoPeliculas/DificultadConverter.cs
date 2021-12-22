using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas
{
    class DificultadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            switch (value.ToString())
            {
                case "Fácil":
                    result = "Khaki";
                    break;

                case "Media":
                    result = "Goldenrod";
                    break;
                default:
                    result = "Crimson";
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
