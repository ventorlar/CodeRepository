using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace httpSpeed.ViewModel
{
    public partial class NamePopupViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public partial string Name { get; set; } = string.Empty;

        readonly IPopupService popupService;

        public NamePopupViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }

        void OnCancel()
        {
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        void OnSave()
        {
        }

        bool CanSave() => string.IsNullOrWhiteSpace(Name) is false;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Name = (string)query[nameof(NamePopupViewModel.Name)];
        }
    }
}
