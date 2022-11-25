﻿using System.Globalization;
using TickOffList.Models;

namespace TickOffList.Converters;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-25
* @version 1.0
* ==============================================================================*/

public class HabitTickImageButtonIconState : IValueConverter{
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture) {
        if (value is Habit)
        {
            Habit habit = (Habit)value;
            return habit.Finish ? "slide_true.png" : "slide_false.png";
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture) {
        throw new NotImplementedException();
    }
}