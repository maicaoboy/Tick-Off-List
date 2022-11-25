using System.Globalization;
using TickOffList.Models;

namespace TickOffList.Converters;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-25
* @version 1.0
* ==============================================================================*/

public class HabitPageItemTappedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture) =>
        (value as ItemTappedEventArgs)?.Item as Habit;

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}