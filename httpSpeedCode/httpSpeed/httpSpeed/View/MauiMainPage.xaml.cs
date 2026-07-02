using httpSpeed.ViewModel;

namespace httpSpeed.View;

public partial class MauiMainPage : ContentPage
{
	public MauiMainPage(MauiMainPageViewModel mauiMainPageViewModel)
	{
		InitializeComponent();
        BindingContext = mauiMainPageViewModel;

    }
}