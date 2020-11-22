using System;
using System.Globalization;
using System.Windows.Data;

namespace Work_with_API.Helper
{
    class HouseNameToLOGO: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            string house = value.ToString();

            switch (house)
            {
                case "Gryffindor":
                    result = "../img/gryffindor.jpg";
                    break;
                case "Slytherin":
                    result = "../img/slytherin.png";
                    break;
                case "Hufflepuff":
                    result = "../img/hufflepuff.jpg";
                    break;
                case "Ravenclaw":
                    result = "../img/ravenclaw.png";
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
