using SudoWorld.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel
{
    class SudokuGridViewModel:BaseViewModel
    {
        private int _gridId;
        public int GridId { get { return _gridId; } }

        private ObservableCollection<SudokuCellViewModel> sudokuCellViewModels;

        public ObservableCollection<SudokuCellViewModel> SudokuCellViewModels { get; }

        public SudokuGridViewModel(List<int> values, int gridId)
        {
            sudokuCellViewModels =  new ObservableCollection<SudokuCellViewModel>();
            _gridId = gridId;
            for (int i = 0; i < values.Count; i++)
            {
                sudokuCellViewModels.Add(new SudokuCellViewModel(gridId,i,values[i]));
            }
        }


    }
}
