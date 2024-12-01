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

namespace SudoWorld.ViewModel
{
    public class SudokuBoardViewModel:BaseViewModel
    {
        private static readonly int SUDOKU_DIM = 9;
        private SudokuBoardService _sudokuBoardService;
        private readonly DispatcherTimer gameClock;

        private bool _isEraseEnabled;
        private bool _isTmpValuesEnabled;
        private bool _isGamePaused;

        private int _missedValuesCount;
        private string _gameTime;

        private TimeSpan _elapsedTime;
        private CellIndex? _selectedCell = null;


        public ObservableCollection<SudokuGridViewModel> GridViewModels { get; }
        public List<int> NumbersValues { get; set; } = new List<int>();
        public bool IsEraseEnabled { get => _isEraseEnabled; set { _isEraseEnabled = value; if(value==true)IsTmpValuesEnabled = false;  OnPropertyChanged(); } } 
        public bool IsTmpValuesEnabled { get => _isTmpValuesEnabled; set { _isTmpValuesEnabled = value; if (value == true) IsEraseEnabled = false;  OnPropertyChanged(); } }
        public int MissedValuesCount { get => _missedValuesCount;set { _missedValuesCount = value; OnPropertyChanged(); } }
        public bool IsGamePaused { get => _isGamePaused; set { _isGamePaused = value; OnPropertyChanged(); } }

        public string GameTime { get => _gameTime; set { _gameTime = value; OnPropertyChanged(); } }

        public RelayCommand OnNumberClicked { get; set; }
        public RelayCommand OnPauseResumeGame { get; set; }

        public SudokuBoardViewModel(SudokuBoardService sudokuBoardService)
        {
            _sudokuBoardService = sudokuBoardService;
            GridViewModels = new ObservableCollection<SudokuGridViewModel>();
            _isEraseEnabled = false;
            _isTmpValuesEnabled = false;
            _isGamePaused=false;

            OnNumberClicked = new RelayCommand(o => NumberSelected(o),p=>!IsGamePaused); 
            OnPauseResumeGame=new RelayCommand(o=> PauseResumeGame(),p=>true);

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
                int number=buttonNumber;
                if (_selectedCell != null)
                {
                    if (IsTmpValuesEnabled)
                    {
                        GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].writeTmpValue(number);
                    }
                    else 
                    {
                        bool isValid=_sudokuBoardService.IsValueValid(_selectedCell.GridId, _selectedCell.CellId, number);
                        if (isValid == false)
                            MissedValuesCount = MissedValuesCount + 1;
                        GridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].writeValue(number, isValid);
                    }
                }
            }
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
