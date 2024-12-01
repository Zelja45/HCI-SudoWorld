using SudoWorld.Model;
using SudoWorld.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Services
{
    public class SudokuBoardService
    {
        private SudokuBoard _board;
        private int _valuesToAdd;
        
        public  SudokuBoard Board { get=>_board; set { _board = value; } }
        public async Task GetNewSudokuBoard()
        {
            _valuesToAdd = 0;
            _board=await new SudokuValuesProvider().getSudokuGrid();
            for(int i = 0; i < _board.Grids.Count; i++)
            {
                for(int j=0;j<_board.Grids[i].Values.Count; j++)
                {
                    if (_board.Grids[i].Values[j]==0)
                        _valuesToAdd++;
                }
            }
        }

        public bool IsValueValid(int gridId,int cellId,int value)
        {
            if (_board.Grids[gridId].Solution[cellId] == value)
            {
                _board.Grids[gridId].Values[cellId] = value;
                _valuesToAdd--;
                return true;
            }
            else
                return false;
        }
        public int GetHintValue(int gridId,int cellId)
        {
            _board.Grids[gridId].Values[cellId] = _board.Grids[gridId].Solution[cellId];
            return _board.Grids[gridId].Solution[cellId];
        }
        public bool IsSudokuBoardCompleted()
        {
            return _valuesToAdd == 0;
        }
    }
}
