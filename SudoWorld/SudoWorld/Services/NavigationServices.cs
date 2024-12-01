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
        BaseViewModel? CurrentView { get; }
        Task NavigateTo<T>() where T : BaseViewModel;
    }
    public class NavigationServices:ObservableObject, INavigationService    
    {
        private BaseViewModel? _currentView;
        private Func<Type, BaseViewModel> _viewModelFactory;

        public BaseViewModel? CurrentView
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
        public async Task NavigateTo<TBaseViewModel>() where TBaseViewModel : BaseViewModel
        {
            if (_currentView != null)
            {
                CurrentView!.Dispose();
            }
            BaseViewModel viewModel=_viewModelFactory.Invoke(typeof(TBaseViewModel));
            await viewModel.Initialize();
            if (_currentView != null && _currentView.GetType() == typeof(TBaseViewModel))
            {
                CurrentView = null;
                await Task.Delay(5); //to catch this null if views before and after are same and can call property changed
            }
            CurrentView = viewModel;    
        }
    }
}
