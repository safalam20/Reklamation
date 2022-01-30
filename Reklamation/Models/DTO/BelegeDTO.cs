using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    [Keyless]
    public class BelegeDTO
    {
        public int BelID { get; set; }
        public short Mandant { get; set; }
        public int Vorgangsnummer { get; set; }
        public DateTime? Belegdatum { get; set; }
        public short? Belegjahr { get; set; }
        public string Referenznummer { get; set; }
        public decimal? Nettobetrag { get; set; }
        public short? AuftragsJahr { get; set; }
        public int? Auftragsnummer { get; set; }
        public short? LieferscheinJahr { get; set; }
        public int? Lieferscheinnummer { get; set; }
        public short? RechnungsJahr { get; set; }
        public int? Rechnungsnummer { get; set; }
        public string Kundennummer { get; set; }
        public string Kundenname { get; set; }
        public string Liefername { get; set; }
        public string A1PLZ { get; set; }
        public string A1Ort { get; set; }
        public string A1Land { get; set; }

    }
}
