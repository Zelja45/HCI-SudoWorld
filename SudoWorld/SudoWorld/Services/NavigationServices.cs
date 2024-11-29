using SudoWorld.ViewModel;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>() where T : BaseViewModel;
    }
    public class NavigationServices:ObservableObject, INavigationService    
    {
        private BaseViewModel _currentView;
        private Func<Type, BaseViewModel> _viewModelFactory;

        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            private set
            {
                _currentView = value;
                OnPropertyChanged();    
            }
        }
        public NavigationServices(Func<Type,BaseViewModel> viewModelFactory)
        {
            _viewModelFactory= viewModelFactory;
        }
        public void NavigateTo<TBaseViewModel>() where TBaseViewModel : BaseViewModel
        {
            BaseViewModel viewModel=_viewModelFactory.Invoke(typeof(TBaseViewModel));
            CurrentView = viewModel;    

            
        }
    }
}
