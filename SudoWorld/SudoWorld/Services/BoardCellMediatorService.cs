using SudoWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Services
{
    public static class BoardCellMediatorService
    {
        public delegate void SelectedCellIndexChangedHandler(CellIndex? cellIndex);
        public static event SelectedCellIndexChangedHandler SelectedCellIndexChanged;

        public static void NotifyBoardSelectedCellIndexChanged(CellIndex? cellIndex)
        {
            SelectedCellIndexChanged?.Invoke(cellIndex);
        }
    }
}
