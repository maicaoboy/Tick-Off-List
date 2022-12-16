using System.Globalization;
using TickOffList.Models;

namespace TickOffList.Converters;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-25
* @version 1.0
* ==============================================================================*/
    public object Convert(object value, Type targetType, object parameter,
            Habit habit = (Habit)value;
            return habit.Finish ? "finish.png" : habit.IconName;
        }
        return null;
    }

        throw new NotImplementedException();
    }
}