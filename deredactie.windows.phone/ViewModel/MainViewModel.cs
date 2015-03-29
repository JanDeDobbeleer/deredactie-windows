using deredactie.windows.api.Service;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace deredactie.windows.phone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NewsService _newsService;

        public MainViewModel(NewsService newsService, INavigationService navigationService, IMessenger messenger) : base(navigationService, messenger)
        {
            _newsService = newsService;
        }
    }
}