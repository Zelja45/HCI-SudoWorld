using SudoWorld.Model;
using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SudoWorld.ViewModel
{
    public class SudokuBoardViewModel:BaseViewModel
    {
        private static readonly int SUDOKU_DIM = 9;
        private static readonly int SUDOKU_MAX_MISSES_COUNT = 5;
        private SudokuBoardService _sudokuBoardService;
        private PlayersInfoService _playersInfoService;
        private DispatcherTimer gameClock;

        private bool _isEraseEnabled;
        private bool _isTmpValuesEnabled;
        private bool _isGamePaused;
        private bool _isDialogOpened;
        private bool _isWinningGame;

        private int _missedValuesCount;
        private string _gameTime;
        private string _dialogTextTitle;
        private string _dialogTextSubtitle;

        private int _tokensBalance;
        private TimeSpan _elapsedTime;
        private CellIndex? _selectedCell = null;


        public ObservableCollection<SudokuGridViewModel> GridViewModels { get; set; }
        public List<int> NumbersValues { get; set; } = new List<int>();
        public bool IsEraseEnabled { get => _isEraseEnabled; set { _isEraseEnabled = value; if(value==true)IsTmpValuesEnabled = false;  OnPropertyChanged(); } } 
        public bool IsTmpValuesEnabled { get => _isTmpValuesEnabled; set { _isTmpValuesEnabled = value; if (value == true) IsEraseEnabled = false;  OnPropertyChanged(); } }
        public int MissedValuesCount { get => _missedValuesCount;set { _missedValuesCount = value; OnPropertyChanged(); } }
        public bool IsGamePaused { get => _isGamePaused; set { _isGamePaused = value; OnPropertyChanged(); } }
        public bool IsDialogOpened { get => _isDialogOpened; set { _isDialogOpened = value; OnPropertyChanged(); } }
        public bool IsWinningGame { get => _isWinningGame; set { _isWinningGame = value; OnPropertyChanged(); } }
        public string DialogTextTitle { get => _dialogTextTitle; set { _dialogTextTitle = value; OnPropertyChanged(); } }
        public string DialogTextSubtitle { get => _dialogTextSubtitle; set { _dialogTextSubtitle = value; OnPropertyChanged(); } }
        public int TokensBalance { get => _tokensBalance; set { _tokensBalance = value; OnPropertyChanged(); } }

        public string GameTime { get => _gameTime; set { _gameTime = value; OnPropertyChanged(); } }

        public RelayCommand OnNumberClicked { get; set; }
        public RelayCommand OnPauseResumeGame { get; set; }
        public RelayCommand OnHintClicked { get; set; }

        public SudokuBoardViewModel(SudokuBoardService sudokuBoardService,PlayersInfoService playersInfoService)
        {
            _sudokuBoardService = sudokuBoardService;
            _playersInfoService = playersInfoService;
            GridViewModels = new ObservableCollection<SudokuGridViewModel>();
            _isEraseEnabled = false;
            _isTmpValuesEnabled = false;
            _isGamePaused=false;

            TokensBalance=_playersInfoService.PlayerInfo.TokensBalance;

            OnNumberClicked = new RelayCommand(o => NumberSelected(o),p=>!IsGamePaused); 
            OnPauseResumeGame=new RelayCommand(o=> PauseResumeGame(),p=>true);
            OnHintClicked=new RelayCommand(o=> UseHint(),p=>true);

            for(int i = 1; i <= 9; i++)
            {
                NumbersValues.Add(i);
            }

            GameTime = "00:00";
            _elapsedTime = TimeSpan.Zero;
            gameClock = new DispatcherTimer();
            gameClock.Interval = TimeSpan.FromSeconds(1);
            gameClock.Tick += OnGameClockTick;
            gameClock.Start();
            createGridAndCellsViews();
            BoardCellMediatorService.SelectedCellIndexChanged += OnSelectedCell;
        }

        public void OnSelectedCell(CellIndex? index)
        {
            if (_selectedCell != null)
            {
                GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].otherCellIsSelected() ;
            }
            _selectedCell = index;
            if (IsEraseEnabled&&_selectedCell!=null)
            {
                GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].removeValue();
                _selectedCell = null;
            }
        }
        private void NumberSelected(object param)
        {
            if(param is int buttonNumber)
            {
                if (_selectedCell != null)
                {
                    if (IsTmpValuesEnabled)
                    {
                        GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].writeTmpValue(buttonNumber);
                    }
                    else 
                        WriteGuessToCell(buttonNumber);
                }
            }
        }
        private void UseHint()
        {
            if (_selectedCell != null&&TokensBalance>=PlayersInfoService.SUDOKU_HINT_COST)
            {
                GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].writeValue(_sudokuBoardService.GetHintValue(_selectedCell.GridId, _selectedCell.CellId),true);
                TokensBalance=_playersInfoService.UseHint();
            }
        }
        private void WriteGuessToCell(int value)
        {
            bool isValid = _sudokuBoardService.IsValueValid(_selectedCell.GridId, _selectedCell.CellId, value);
            if (isValid == false)
                MissedValuesCount = MissedValuesCount + 1;
            GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].writeValue(value, isValid);
            CheckForGameEnd();
        }
        private void CheckForGameEnd()
        {
            if (MissedValuesCount == SUDOKU_MAX_MISSES_COUNT)
            {
                OnMaxMisses();
            }
            else if(_sudokuBoardService.IsSudokuBoardCompleted())
            {
                OnSudokuBoardCompleted();
            }
        }
        private void OnSudokuBoardCompleted()
        {
            PauseResumeGame();
            
            DialogTextTitle = "Congratulations!";
            string addition = "";
            if (_playersInfoService.PlayerInfo.GetGameDifficultyByName(_sudokuBoardService.Board.Difficulty).BestTime > _elapsedTime)
            {
                addition = " and set your new best score!!!";
            }
            else
                addition = " .";
            DialogTextSubtitle = "You solved " + _sudokuBoardService.Board.Difficulty.ToLower() + " sudoku in " + GameTime+addition;
            _playersInfoService.AddFinishedGameInfo(_sudokuBoardService.Board.Difficulty, _elapsedTime, MissedValuesCount);
            IsDialogOpened = true;
            IsWinningGame = true;
        }
        private void OnMaxMisses()
        {
            PauseResumeGame();
           
            DialogTextTitle = "Game over!";
            DialogTextSubtitle = "Falling is part of the journey to success. Let’s go again!";
            IsDialogOpened = true;
            IsWinningGame = false;
        }
        private void OnGameClockTick(object? sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            GameTime = _elapsedTime.ToString(@"mm\:ss");
        }
        public void PauseResumeGame()
        {
            if (IsGamePaused)
            {
                gameClock.Start();
                IsGamePaused = false;
            }
            else
            {
                gameClock.Stop();
                IsGamePaused = true;
            }
        }


        private void createGridAndCellsViews()
        {
            for(int i = 0; i < SUDOKU_DIM; i++)
            {
                GridViewModels.Add(new SudokuGridViewModel(_sudokuBoardService.Board.Grids[i].Values,gridId:i));
            }
        }
        public override void Dispose()
        {
            BoardCellMediatorService.SelectedCellIndexChanged -= OnSelectedCell;
        }
    }
}
