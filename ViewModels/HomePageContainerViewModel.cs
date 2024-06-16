using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace avalonia_new.ViewModels
{
    public class HomePageContainerViewModel : ViewModelBase
    {
        public ICommand ChangeTabCommand { get; }
        public HomePageContainerViewModel(IRegionManager regionManager) : base(regionManager)
        {
            ChangeTabCommand = new DelegateCommand<object>(ChangeTab);
        }

        private void ChangeTab(object tabIndex)
        {

        }
    }
}
