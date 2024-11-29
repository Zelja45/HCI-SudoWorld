using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class SudokuBoard
    {
        private List<SudokuGrid> _grids;
        private String _difficulty;
        public String Difficulty { get; set; }
        public List<SudokuGrid> Grids { get; set; }

        public SudokuBoard(List<SudokuGrid> grids,String difficulty) 
        {
            _difficulty= difficulty;
            _grids = grids;
        }

    }
}
