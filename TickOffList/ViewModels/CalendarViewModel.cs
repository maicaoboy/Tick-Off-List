using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using TickOffList.Converters;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels; 

public class CalendarViewModel : ObservableObject{

    private ObservableCollection<Meeting> _meetings;

    private DateTime _minDateTime;

    private DateTime _maxDateTime;

    private DateTime _displayDate;

    private IHabitStorage _habitStorage;

    private IMeetingColorConverter _meetingColorConverter;


    public CalendarViewModel(IHabitStorage habitStorage, IMeetingColorConverter meetingColorConverter) {
        this._habitStorage = habitStorage;
        this._meetingColorConverter = meetingColorConverter;

        _lazyNavigatedToCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(NavigatedToCommandFunction));

        this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
        this.MinDateTime = DateTime.Now.Date.AddMonths(-3);
        this.MaxDateTime = DateTime.Now.AddMonths(3);


        _meetings = new ObservableCollection<Meeting>();


        // // Creating an instance for the business object class.
        // Meeting meeting = new Meeting();
        // // Setting the start time of an event.
        // meeting.From = DateTime.Today.Date.AddHours(9);
        // // Setting the end time of an event.
        // meeting.To = meeting.From.AddHours(2);
        // // Setting the subject for an event.
        // meeting.EventName = "喝水打卡";
        // // Setting the background color for an event.
        // meeting.Background = Brush.Orange;
        // // Creating an instance for the collection of business objects.
        // var Meetings = new ObservableCollection<Meeting>();
        // // Adding a business object to the business object Collection.
        // _meetings.Add(meeting);
        //
        //
        // Meeting meeting1 = new Meeting();
        // // Setting the start time of an event.
        // meeting1.From = DateTime.Today.AddDays(-1).AddHours(8);
        // // Setting the end time of an event.
        // meeting1.To = meeting.From.AddDays(-1).AddHours(10);
        // // Setting the subject for an event.
        // meeting1.EventName = "运动打卡";
        // // Setting the background color for an event.
        // meeting1.Background = Brush.Orange;
        // // Creating an instance for the collection of business objects.
        // // Adding a business object to the business object Collection.
        // _meetings.Add(meeting1);
        //
        // _meetings.Add(new Meeting() {
        //     From = DateTime.Today.AddDays(-20).AddHours(8),
        //     // Setting the end time of an event.
        //     To = meeting.From.AddDays(-20).AddHours(10),
        //     // Setting the subject for an event.
        //     EventName = "运动打卡20",
        //     // Setting the background color for an event.
        //     Background = Brush.Orange
        // });
        // for (var i = 0; i < 10; i++) {
        //     _meetings.Add(new Meeting()
        //     {
        //         From = DateTime.Today.AddDays(-48).AddHours(8),
        //         // Setting the end time of an event.
        //         To = meeting.From.AddDays(-50).AddHours(10),
        //         // Setting the subject for an event.
        //         EventName = "运动打卡48",
        //         // Setting the background color for an event.
        //         Background = Brush.Orange
        //     });
        //     _meetings.Add(new Meeting()
        //     {
        //         From = DateTime.Today.AddHours(-1),
        //         // Setting the end time of an event.
        //         To = meeting.From.AddHours(-1),
        //         // Setting the subject for an event.
        //         EventName = "运动打卡48",
        //         // Setting the background color for an event.
        //         Background = Brush.Orange
        //     });
        // }

    }

    private Lazy<AsyncRelayCommand> _lazyNavigatedToCommand;

    public AsyncRelayCommand NavigatedToCommand =>
        _lazyNavigatedToCommand.Value;

    public async Task NavigatedToCommandFunction() {
        Meetings.Clear();
        var habits = await _habitStorage.ListAsync();
        var listRecordAsync = await _habitStorage.ListRecordAsync(MinDateTime, MaxDateTime);
        Dictionary<int, Habit> habitMap = new Dictionary<int, Habit>();
        foreach (var habit in habits) {
            habitMap.Add(habit.Id, habit);
        }
        foreach (var habitRecord in listRecordAsync) {
            var meeting = new Meeting() {
                EventName = habitMap[habitRecord.Hid].Title,
                From = habitRecord.RecordDate,
                To = habitRecord.RecordDate.AddMinutes(1),
                Background =
                    _meetingColorConverter.IconNameToBrush(
                        habitMap[habitRecord.Hid].IconName)
            };
             Meetings.Add(meeting);
        }
    }

    public ObservableCollection<Meeting> Meetings {
        get => _meetings;
        set => SetProperty(ref _meetings, value);
    }

    public DateTime MinDateTime {
        get => _minDateTime;
        set => _minDateTime = value;
    }

    public DateTime MaxDateTime {
        get => _maxDateTime;
        set => _maxDateTime = value;
    }

    public DateTime DisplayDate {
        get => _displayDate;
        set => _displayDate = value;
    }
}