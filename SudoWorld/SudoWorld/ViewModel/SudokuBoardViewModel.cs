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
        private SudokuBoardService _sudokuBoardService;
        private ObservableCollection<SudokuGridViewModel> _gridViewModels;
        private bool _isEraseEnabled;
        private bool _isTmpValuesEnabled;
        public bool IsEraseEnabled { get => _isEraseEnabled; set { _isEraseEnabled = value; OnPropertyChanged(); } } ;
        public bool IsTmpValuesEnabled { get => _isTmpValuesEnabled; set { _isTmpValuesEnabled = value; OnPropertyChanged(); } }

        private CellIndex? _selectedCell = null;

        public RelayCommand EnableDissableErase { get; }
        public RelayCommand EnableDissableTmpValues { get; }

        public SudokuBoardViewModel(SudokuBoardService sudokuBoardService)
        {
            IsEraseEnabled = false;
            IsTmpValuesEnabled = false;

        }

        public void OnSelectedCell(CellIndex index)
        {
            if (_selectedCell != null)
            {
                _gridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].selectDeselect();
            }
            _selectedCell = index;
            if (IsEraseEnabled)
            {
                _gridViewModels[_selectedCell.GridId].SudokuCellViewModels[_selectedCell.CellId].removeValue();
            }
        }
        

        
    }
}
