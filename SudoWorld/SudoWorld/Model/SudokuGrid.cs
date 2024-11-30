using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class SudokuGrid
    {
        private List<int> _values;
        private List<int> _solution;
        public List<int> Values { get=>_values; set { _values = value; } }
        public List<int> Solution { get=>_solution; set { _solution = value; } }

        public SudokuGrid(List<int> values,List<int> soultion) 
        {
            _solution = soultion;
            _values = values;
        }
    }
}
