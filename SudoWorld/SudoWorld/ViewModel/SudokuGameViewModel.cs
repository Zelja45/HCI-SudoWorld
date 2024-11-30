using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    public class SudokuGameViewModel:BaseViewModel
    {
        public SudokuBoardViewModel? BoardViewModel { get; set; }
        private SudokuBoardService _boardService;
        public SudokuBoardService BoardService { get => _boardService; }

        private INavigationService _navigationService;

        public SudokuGameViewModel(INavigationService navigationService,SudokuBoardService boardService)
        {
            _boardService = boardService;
            _navigationService = navigationService;
        }
        public override void Dispose()
        {
             BoardViewModel!.Dispose();
             BoardViewModel = null;
        }
        public override async Task Initialize()
        {
            await _boardService.GetNewSudokuBoard();
            BoardViewModel = new SudokuBoardViewModel(_boardService);
        }
       


    }
}
