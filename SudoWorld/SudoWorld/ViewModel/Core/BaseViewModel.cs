using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.ViewModel.Core
{
    public class BaseViewModel : ObservableObject
    {
        public virtual void Dispose() { }
        public virtual async Task Initialize() { }
    }
}
