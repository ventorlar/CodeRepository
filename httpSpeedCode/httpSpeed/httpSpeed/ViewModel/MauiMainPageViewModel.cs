using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using httpSpeed.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace httpSpeed.ViewModel
{
    public partial class MauiMainPageViewModel: ObservableObject
    {
        private readonly IPopupService popupService;
        public MauiMainPageViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }

        [ObservableProperty]
        private string domain = "google.com";

        [ObservableProperty]
        private string port = "443";

        [ObservableProperty]
        private string delayTime = string.Empty;

        [ObservableProperty]
        private Color buttonColor=Colors.Blue;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private string selectedPickerItems = "https";

        [ObservableProperty]
        ObservableCollection<string> pickerItems = new ObservableCollection<string>() { "http","https"};

        [RelayCommand]
        public async Task DisplayPopup(string msg)
        {
            var queryAttributes = new Dictionary<string, object>
            {
                [nameof(NamePopupViewModel.Name)] = msg
            };

            await this.popupService.ShowPopupAsync<NamePopupViewModel>(
                Shell.Current,
                options: PopupOptions.Empty,
                shellParameters: queryAttributes);
        }

        [RelayCommand]
        private async void Start()
        {
            CheckParameters cp=new CheckParameters();
            //if (!cp.PortIsValid(Port))
            //{
            //    await DisplayPopup("端口号错误！");
            //    return;
            //}
            if (cp.DomainIsValid(Domain))
            {
                await DisplayPopup("域名不能包含协议！");
                return;
            }
            string ip = SelectedPickerItems+"://" + Domain;
            TimeWatch timeWatch = new TimeWatch();
            ResultModel rm = new ResultModel();
            rm = timeWatch.TimeCal(ip);
            DelayTime = rm.delayTime;
            if (rm.hasRes == "yes") ErrorMessage = "请求成功";
            if (rm.hasRes == "no") ErrorMessage = rm.errMessage;
        }

        [RelayCommand]
        private void PickerSelectedIndexChanged(string selectedValue)
        {
            if(selectedValue == "http") Port = "80";
            if(selectedValue == "https") Port = "443";
        }

        [RelayCommand]
        private async void Coyptoclipboard()
        {
            await Clipboard.Default.SetTextAsync(ErrorMessage);
        }
    }
}
