using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SudoWorld.ViewModel
{
    public class HomeViewModel:BaseViewModel
    {
      

        private INavigationService _navigation;

        public INavigationService Navigation { get => _navigation; set { _navigation = value; OnPropertyChanged(); } }
        public PlayersInfoService PlayersInfoService { get; }
        public RelayCommand NavigateToStatisticsCommand { get; }
        public RelayCommand NavigateToNewGameCommand { get; }
        

        public HomeViewModel(INavigationService navService,PlayersInfoService playersInfoService)
        {
            Navigation = navService;
            PlayersInfoService = playersInfoService;
            NavigateToStatisticsCommand = new RelayCommand(o => { Navigation.NavigateTo<StatisticsViewModel>(); }, o => true);
            NavigateToNewGameCommand = new RelayCommand(async o => { try { await Navigation.NavigateTo<SudokuGameViewModel>(); } catch (Exception)
                {
                    MessageBox.Show("Something went wrong. Try again!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                } }, o => true);
        }
    }
}
