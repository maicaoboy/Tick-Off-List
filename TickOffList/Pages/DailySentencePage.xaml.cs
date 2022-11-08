using Refit;
using TickOffList.Services;

namespace TickOffList.Pages;

public partial class DailySentencePage : ContentPage
{
	public DailySentencePage()
	{
		InitializeComponent();

        try {
            var apiClient =
                RestService.For<IDailySentenceService>(DailySentenceService
                    .BaseUrl);
            var dailySentence = apiClient.GetDailySentenceAsync();
            StackLayoutDailySentence.BindingContext = dailySentence;
        } catch (Exception e) {
            Console.WriteLine("Oups " + e);
        }
	}
}