using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace deredactie.windows.phone.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value == _isBusy)
                    return;

                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        private bool _viewLoadedCommandEnabled = true;
        public bool ViewLoadedCommandEnabled
        {
            get
            {
                return _viewLoadedCommandEnabled;
            }
            set
            {
                if (_viewLoadedCommandEnabled == value)
                    return;

                _viewLoadedCommandEnabled = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand ViewLoadedCommand { get; protected set; }

        public BaseViewModel()
        {
        }

        public BaseViewModel(INavigationService navigationService, IMessenger messenger) : base(messenger)
        {
            _navigationService = navigationService;
        }
    }
}
