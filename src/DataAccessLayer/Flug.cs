using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Flug
    {
        public int Id { get; set; }
        public string Abflugort { get; set; }
        public string Zielort { get; set; }
        public DateTime Datum { get; set; }
        public List<Buchung> Buchungen { get; set; } = new List<Buchung>();
    }
}
