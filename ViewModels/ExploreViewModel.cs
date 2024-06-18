using Avalonia;
using avalonia_new.Helper;
using avalonia_new.Model;
using avalonia_new.Region;
using avalonia_new.Views;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Styling;
using Prism.Events;
using avalonia_new.Events;
using System.Globalization;

namespace avalonia_new.ViewModels
{
    public class ExploreViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        bool _ShowPopup = false;
        public bool ShowPopup
        {
            get => _ShowPopup;
            set
            {
                if (_ShowPopup != value)
                {
                    _ShowPopup = value;
                    _eventAggregator.GetEvent<PopUpEvent>().Publish(new PopUpEventData(value));
                    RaisePropertyChanged(nameof(ShowPopup));
                }
            }
        }

        public ICommand ButtonCommand { get; }
        public ICommand ClosePopup { get; }

        private ObservableCollection<ExploreModel> _ExploreList = [];
        private ObservableCollection<ExploreModel> ExploreList
        {
            get => _ExploreList;
            set => SetProperty(ref _ExploreList, value);

        }
        public ExploreViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager)
        {
            _eventAggregator = eventAggregator;
            ButtonCommand = new DelegateCommand<ExploreItemModel>(GeneralCommand);
            ClosePopup = new DelegateCommand(CloseDialogPopup);
            GenerateExploreDat();
        }

        private void CloseDialogPopup()
        {
            ShowPopup = false;
        }
        private void GeneralCommand(ExploreItemModel obj)
        {           
            switch(obj.Id)
            {
                case 1:
                    ToastHelper.ShowToast("Success toast", Services.ToastService.ToastType.Success);
                    break;
                case 2:
                    ToastHelper.ShowToast("Warning toast", Services.ToastService.ToastType.Warning);
                    break;
                case 3:
                    ToastHelper.ShowToast("Error toast", Services.ToastService.ToastType.Error);
                    break;
                case 4:
                    ShowPopup = true;                  
                    break;
                case 5:                   
                    _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, nameof(ChildView));
                    break;
                case 6:
                    var fluentTheme = Application.Current?.RequestedThemeVariant;
                    if (fluentTheme != ThemeVariant.Dark)
                    {
                        Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
                    }
                    break;
                case 7:
                    var currentTheme = Application.Current?.RequestedThemeVariant;
                    if (currentTheme != ThemeVariant.Light)
                    {
                        Application.Current.RequestedThemeVariant = ThemeVariant.Light;
                    }
                    break;

                case 8:
                    Assets.Lang.Resources.Culture = new CultureInfo("en-US");
                    break;

                case 9:
                    Assets.Lang.Resources.Culture = new CultureInfo("ne-NP");
                    break;
            }
        }

        void GenerateExploreDat()
        {
            ExploreList.Add(new ExploreModel()
            {
                Id = 1,
                Title = "Toast & Font Icon",
                FeatureList =
                [
                        new ExploreItemModel { Id = 1, FeatureName = "Success Toast", FontIcon="\uf133" },
                        new ExploreItemModel { Id = 2, FeatureName = "Warning Toast" , FontIcon="\uf028"},
                         new ExploreItemModel { Id = 3, FeatureName = "Error Toast",FontIcon="\uf159" }
                ]
            });
            ExploreList.Add(new ExploreModel()
            {
                Id = 2,
                Title = "Display Alert",
                FeatureList =
                [
                        new ExploreItemModel { Id = 4, FeatureName = "Dialog Popup",FontIcon="\uf554" }
                ]
            });

            ExploreList.Add(new ExploreModel()
            {
                Id = 3,
                Title = "Navigation",
                FeatureList =
                [
                        new ExploreItemModel { Id = 5, FeatureName = "Navigation",FontIcon="\uf054" }
                ]
            });

            ExploreList.Add(new ExploreModel()
            {
                Id = 4,
                Title = "Theme",
                FeatureList =
                [
                        new ExploreItemModel { Id = 6, FeatureName = "Dark Theme",FontIcon="\uf50e" },
                        new ExploreItemModel { Id = 7, FeatureName = "Light Theme",FontIcon="\uf50e" }
                ]
            });

            ExploreList.Add(new ExploreModel()
            {
                Id = 5,
                Title = "Localization",
                FeatureList =
                [
                        new ExploreItemModel { Id = 8, FeatureName = "English",FontIcon="\uf5ca" },
                        new ExploreItemModel { Id = 9, FeatureName = "Nepali",FontIcon="\uf5ca" }
                ]
            });

        }
    }
}
