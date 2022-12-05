using System.Globalization;

namespace TickOffList.Converters;

// Author: 李宏彬
public class RecordCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
        if (value is int)
        {
            int recordCount = (int)value;
            return recordCount != 0 ? "已打卡" + recordCount + "天" : "无打卡记录";
        }

        return "打卡记录获取出错";
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}