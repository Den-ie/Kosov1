using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosov1
{
    public class Discipline
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int ClassNumber { get; set; }
        public int HoursAmount { get; set; }
    }

    public static class Value
    {
        public static ObservableCollection<Discipline> disciplines;
    }
}
