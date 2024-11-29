using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class CellIndex
    {
        private int _gridId;
        private int _cellId;
       
        public int GridId { get; }
        public int CellId { get { return _cellId; } }

        public CellIndex(int gridId, int cellId)
        {
            _gridId = gridId;  
            _cellId = cellId;
        }
    }
}
