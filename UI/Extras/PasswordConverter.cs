using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UI.Extras
{
    [ValueConversion(typeof(String), typeof(String))]
    public class PasswordConverter : IValueConverter
    {

        public string VisiblePassword { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            VisiblePassword = (string)value;
            return new string(VisiblePassword.Select(c => '*').ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VisiblePassword;
        }
    }
}
