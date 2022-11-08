using Refit;
using TickOffList.Services;

namespace TickOffList;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        button_gethitokoto.Clicked += Button_gethitokoto_Clicked;
    }

    private async void Button_gethitokoto_Clicked(object sender, EventArgs e) {
        try
        {
            var apiClient =
                RestService.For<IDailySentenceService>(DailySentenceService
                    .BaseUrl);
            var dailySentence = apiClient.GetDailySentenceAsync();
            StackLayoutDailySentence.ItemsSource = dailySentence;
        }
        catch (Exception e)
        {
            Console.WriteLine("Oups " + e);
        }
    }
}