using httpSpeed.ViewModel;

namespace httpSpeed.View;

public partial class NamePopup : ContentView
{
    public NamePopup(NamePopupViewModel namePopupViewModel)
    {
        InitializeComponent();
        BindingContext = namePopupViewModel;
    }
}