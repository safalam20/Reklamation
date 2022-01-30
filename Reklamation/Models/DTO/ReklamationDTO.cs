using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    public class ReklamationDTO
    {
        public string Status { get; set; }
        public DateTime? ReklamationsKundeDatum { get; set; }
        public string RVENummer { get; set; }
        public string GutschriftNummer { get; set; }
        public string Stornorechnungsnummer { get; set; }
        public string RVEStornorechnung { get; set; }
        public DateTime? Ablehnungsdatum { get; set; }
        public string Abholenummer { get; set; }
        public string AbholeFirma { get; set; }
        public DateTime? Abholetermin { get; set; }
        public decimal? Versandkosten { get; set; }
        public int? WiedereinlagerungGebühr { get; set; }
        public string AB_StornoBelNum { get; set; }
        public string LF_RuckBelNum { get; set; }
        public string RVEAB_StornoBelNum { get; set; }
        public string RVELF_RuckBelNum { get; set; }
        public string Ersteller { get; set; }
        public DateTime? Erstelldatum { get; set; }
        public string Updater { get; set; }
        public DateTime? Updatedatum { get; set; }
        public string WeitereNotizen { get; set; }
    }
}
