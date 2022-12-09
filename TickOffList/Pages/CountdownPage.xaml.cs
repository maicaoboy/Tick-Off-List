namespace TickOffList.Pages;

// author: ÌÕ¾²Áú
public partial class CountdownPage : ContentPage {
    public CountdownPage() {
        InitializeComponent();

        InitializePickers();
    }

    private void InitializePickers() {
        for (var i = 0; i <= 99; i++)
            if (i <= 9) {
                HourPicker.Items.Add($"0{i}");
                MinutePicker.Items.Add($"0{i}");
                SecondPicker.Items.Add($"0{i}");
            } else if (i <= 59) {
                MinutePicker.Items.Add($"{i}");
                SecondPicker.Items.Add($"{i}");
            } else {
                HourPicker.Items.Add($"{i}");
            }

        HourPicker.SelectedItem = "00";
        MinutePicker.SelectedItem = "00";
        SecondPicker.SelectedItem = "00";
    }
}