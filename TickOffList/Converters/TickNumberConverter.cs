using System.Globalization;
using TickOffList.Models;

namespace TickOffList.Converters; 

public class TickNumberConverter : IValueConverter{
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture) {
        if (value is Habit)
        {
            Habit habit = (Habit)value;
            return "今日打卡次数:" +habit.QuantityToday + "/" + habit.Quantity;
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture) {
        throw new NotImplementedException();
    }
}