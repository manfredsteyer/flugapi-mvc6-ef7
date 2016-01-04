using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Buchung
    {
        public int BuchungId { get; set; }
        public Flug Flug { get; set; }
        public int FlugId { get; set; }
        public int PassagierId { get; set; }
        public decimal Preis { get; set; }
    }
}
