
using Prism.Regions;

namespace avalonia_new.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }
    }
}
