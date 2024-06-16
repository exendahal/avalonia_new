using avalonia_new.Helper;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace avalonia_new.ViewModels
{
    public class ExploreViewModel : ViewModelBase
    {
        public ICommand ButtonCommand { get; }
        public ExploreViewModel(IRegionManager regionManager) : base(regionManager)
        {
            ButtonCommand = new DelegateCommand<string>(GeneralCommand);
        }

        private void GeneralCommand(string obj)
        {
            int type = int.Parse(obj);
            switch(type)
            {
                case 0:
                    ToastHelper.ShowToast("Success toast", Services.ToastService.ToastType.Success);
                    break;
                case 1:
                    ToastHelper.ShowToast("Warning toast", Services.ToastService.ToastType.Warning);
                    break;
                case 2:
                    ToastHelper.ShowToast("Error toast", Services.ToastService.ToastType.Error);
                    break;
            }
        }
    }
}
