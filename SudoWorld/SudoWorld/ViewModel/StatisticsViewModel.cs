using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    public class StatisticsViewModel:BaseViewModel
    {
        private INavigationService _navigationService;
        public PlayersInfoService PlayersInfoService { get; }
        public RelayCommand GoBackCommand { get; }

        public StatisticsViewModel(INavigationService navigationService, PlayersInfoService playersInfoService)
        {
            _navigationService = navigationService;
            PlayersInfoService = playersInfoService;
            GoBackCommand = new RelayCommand(o => _navigationService.NavigateTo<HomeViewModel>(), p => true);
        }


    }
}
