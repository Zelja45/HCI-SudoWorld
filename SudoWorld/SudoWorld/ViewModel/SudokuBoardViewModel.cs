using SudoWorld.Model;
using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    public class SudokuBoardViewModel:BaseViewModel
    {
        private static readonly int SUDOKU_DIM = 9;
        private SudokuBoardService _sudokuBoardService;
        
        private bool _isEraseEnabled;
        private bool _isTmpValuesEnabled;


        public ObservableCollection<SudokuGridViewModel> GridViewModels { get; }
        public bool IsEraseEnabled { get => _isEraseEnabled; set { _isEraseEnabled = value; if(value==true)IsTmpValuesEnabled = false;  OnPropertyChanged(); } } 
        public bool IsTmpValuesEnabled { get => _isTmpValuesEnabled; set { _isTmpValuesEnabled = value; if (value == true) IsEraseEnabled = false;  OnPropertyChanged(); } }

        private CellIndex? _selectedCell = null;

        

        public SudokuBoardViewModel(SudokuBoardService sudokuBoardService)
        {
            _sudokuBoardService = sudokuBoardService;
            GridViewModels = new ObservableCollection<SudokuGridViewModel>();
            _isEraseEnabled = false;
            _isTmpValuesEnabled = false;
            
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
