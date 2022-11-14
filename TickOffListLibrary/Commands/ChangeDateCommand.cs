using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TickOffList.Models;
using TickOffList.ViewModels;

namespace TickOffList.Commands; 

public class ChangeDateCommand : ICommand{
    public event EventHandler CanExecuteChanged;

    HabitViewModel viewModel;
    public ChangeDateCommand(HabitViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public bool CanExecute(object date)
    {
        return true;
    }

    public void Execute(object date) {
        Reload(date);
    }

    public async void Reload(object date) {
        var dateNum = int.Parse((string)date);
        var dateTime = DateTime.Now.AddDays(-dateNum);

        var habitByWeekDay =await viewModel.HabitStorage.getHabitByWeekDay(Convert
            .ToInt32(dateTime.DayOfWeek.ToString("d")).ToString());
        // var result = habitByWeekDay;
        viewModel.Habits.Clear();
        for (var i = 0; i < habitByWeekDay.Count; i++)
        {
            viewModel.Habits.Add(habitByWeekDay[i]);
        }
    }


}