using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    public class FindBelegDTO
    {
        public string Kundennummer { get; set; }
        public DateTime? Belegdatum { get; set; }
        public string Auftragsnummer { get; set; }
        public string Lieferscheinnummer { get; set; }
        public string Rechnungsnummer { get; set; }
        public string Referenznummer { get; set; }
    }
}
