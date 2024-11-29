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
        public List<int> Values { get; set; }
        public List<int> Solution { get; set; }

        public SudokuGrid(List<int> values,List<int> soultion) 
        {
            _solution = soultion;
            _values = values;
        }
    }
}
