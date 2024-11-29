using SudoWorld.Services;
using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    class SudokuCellViewModel:BaseViewModel
    {
        private int _gridId;
        private int _cellId;
        public int  GridId { get; }
        public int CellId { get; }
        private int _initialValue;

        private string _cellValueToShow="";
        private bool _cellWriteable=false;
        private bool _isSelected = false;
        private bool _isValueValid = false;
        private bool _isTmpValue = false;

        public bool IsValueValid { get { return _isValueValid; } set { _isValueValid = value; OnPropertyChanged(); } }
        public bool IsTmpValue {  get { return _isValueValid; } set { _isTmpValue = value; OnPropertyChanged(); } }
        public bool IsSelected { get => _isSelected; set { _isSelected = value; OnPropertyChanged(); } }
        public string CellValueToShow { get => _cellValueToShow; set { _cellValueToShow = value; OnPropertyChanged(); } }
        public bool CellWriteable { get => _cellWriteable; set { _cellWriteable = value; OnPropertyChanged(); } }

        public SudokuCellViewModel(int gridId,int cellId,int initialValue) {
            _initialValue = initialValue;
            _cellId= cellId;
            _gridId= gridId;
            CellWriteable=initialValue == 0;
            CellValueToShow = initialValue == 0 ? "" : initialValue.ToString();
        } 
        
        public void selectDeselect()
        {
            if (CellWriteable)
            {
                if (IsSelected)
                {
                    IsSelected= false;
                    BoardCellMediatorService.NotifyBoardSelectedCellIndexChanged(null);
                }
                else
                {
                    IsSelected = true;
                    BoardCellMediatorService.NotifyBoardSelectedCellIndexChanged(new Model.CellIndex(GridId, CellId));
                }
            }
        }
        public void writeTmpValue(int value)
        {
            if(IsSelected&&CellWriteable)
            {
                IsTmpValue= true;
                IsValueValid = true;
                CellValueToShow=value.ToString();
                selectDeselect();
            }
        }
        public void writeValue(int value,bool isValid)
        {
            selectDeselect();
            if (isValid)
                CellWriteable = false;
            IsValueValid = isValid;
            CellValueToShow=value.ToString();
            IsTmpValue = false;
            
        }
        public void removeValue()
        {
            if (CellWriteable && IsSelected)
            {
                selectDeselect();
                CellValueToShow = "";
                IsTmpValue = false; 
                IsValueValid= false;
            }
        }


        

    }
}
