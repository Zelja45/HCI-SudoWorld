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
        
        public  SudokuBoard Board { get=>_board; set { _board = value; } }
        public async Task GetNewSudokuBoard()
        {
            _board=await new SudokuValuesProvider().getSudokuGrid();
        }

        public bool IsValueValid(int gridId,int cellId,int value)
        {
            if (_board.Grids[gridId].Solution[cellId] == value)
            {
                _board.Grids[gridId].Values[cellId] = value;
                return true;
            }
            else
                return false;
        }
        public int GetHintValue(int gridId,int cellId,int value)
        {
            _board.Grids[gridId].Values[cellId] = _board.Grids[gridId].Solution[cellId];
            return _board.Grids[gridId].Solution[cellId];
        }
    }
}
