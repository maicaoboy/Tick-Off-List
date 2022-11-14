using System.Globalization;

namespace TickOffList.Converters; 

public class RecordCountConverter : IValueConverter{
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture) =>
        value is int recordCount ? "已打卡" + recordCount + "天" : "无打卡记录";
    

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture) {
        throw new NotImplementedException();
    }
}