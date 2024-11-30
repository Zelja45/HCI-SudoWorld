using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    public class HomeViewModel:BaseViewModel
    {
      

        private INavigationService _navigation;
        public INavigationService Navigation { get => _navigation; set { _navigation = value; OnPropertyChanged(); } }

        public RelayCommand NavigateToRegisterCommand { get; set; }
        public RelayCommand NavigateToNewGameCommand { get; set; }

        public HomeViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToRegisterCommand = new RelayCommand(o => { Navigation.NavigateTo<RegisterViewModel>(); }, o => true);
            NavigateToNewGameCommand = new RelayCommand(async o =>  { await Navigation.NavigateTo<SudokuGameViewModel>(); }, o => true);
        }
    }
}
