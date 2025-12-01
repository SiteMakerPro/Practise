using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Models.Card> Cards { get; set; }
    }
}
