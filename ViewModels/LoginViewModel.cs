
using avalonia_new.Helper;
using avalonia_new.Region;
using avalonia_new.Views;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace avalonia_new.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _Username;
        public string Username
        {
            get => _Username;
            set => SetProperty(ref _Username, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }
        public ICommand LoginCommand { get; }

        public LoginViewModel(IRegionManager regionManager) : base(regionManager)
        {
            LoginCommand = new DelegateCommand(LoginUser);
        }

        private void LoginUser()
        {
            ToastHelper.ShowToast("Welcome", Services.ToastService.ToastType.Success);
            _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, nameof(WelcomePage));
        }
    }
}
