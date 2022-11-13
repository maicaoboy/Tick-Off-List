namespace TickOffList.Pages;

// author: ÌÕ¾²Áú
public partial class CountdownPage : ContentPage
{
    public CountdownPage()
    {
        InitializeComponent();

        InitializePickers();
    }

    private void InitializePickers()
    {
        for (int i = 0; i <= 99; i++)
        {
            if (i <= 9)
            {
                HourPicker.Items.Add("0" + Convert.ToString(i));
                MinutePicker.Items.Add("0" + Convert.ToString(i));
                SecondPicker.Items.Add("0" + Convert.ToString(i));
            }
            else if (i <= 59)
            {
                MinutePicker.Items.Add(Convert.ToString(i));
                SecondPicker.Items.Add(Convert.ToString(i));
            }
            else
            {
                HourPicker.Items.Add(Convert.ToString(i));
            }
        }

        HourPicker.SelectedItem = "00";
        MinutePicker.SelectedItem = "00";
        SecondPicker.SelectedItem = "00";
    }
}