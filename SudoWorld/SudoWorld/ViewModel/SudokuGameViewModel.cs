﻿using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SudoWorld.ViewModel
{
    public class SudokuGameViewModel:BaseViewModel
    {
        public SudokuBoardViewModel? BoardViewModel { get; set; }
        private SudokuBoardService _boardService;
        private PlayersInfoService _playersInfoService;
        public SudokuBoardService BoardService { get => _boardService; }
        public RelayCommand GoBackToHomeView { get; set; }
        public RelayCommand StartNewGameCommand { get; set; }

        private INavigationService _navigationService;

        public SudokuGameViewModel(INavigationService navigationService,SudokuBoardService boardService,PlayersInfoService playersInfoService)
        {
            _boardService = boardService;
            _navigationService = navigationService;
            _playersInfoService = playersInfoService;
            GoBackToHomeView = new RelayCommand(o => _navigationService.NavigateTo<HomeViewModel>(), p => true);
            StartNewGameCommand = new RelayCommand(async o  => { try { await _navigationService.NavigateTo<SudokuGameViewModel>(); } catch (Exception) {
                    MessageBox.Show("Something went wrong. Try again!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                } }, p => true);
        }
        public override void Dispose()
        {
            if(BoardViewModel!=null)
                BoardViewModel!.Dispose();
             BoardViewModel = null;
        }
        public override async Task Initialize()
        {
            await _boardService.GetNewSudokuBoard();
            BoardViewModel = new SudokuBoardViewModel(_boardService,_playersInfoService);
        }

    }
}
