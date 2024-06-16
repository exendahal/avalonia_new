
using Prism.Regions;
using System.ComponentModel.DataAnnotations;

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

        public LoginViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }
    }
}
