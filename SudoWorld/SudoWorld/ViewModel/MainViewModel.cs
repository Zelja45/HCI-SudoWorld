using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation{ get => _navigation; set { _navigation = value; OnPropertyChanged(); } }

        public MainViewModel(INavigationService navService) 
        {
            Navigation= navService;

        }
    }
}
