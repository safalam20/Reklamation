using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
    [Table("KTrkl_Reklamation")]
    public class KTrkl_Reklamation
    {
        [Key]
        public int Rek_ID { get; set; }
        public int? BelID { get; set; }
        public short? Mandant { get; set; }
        public string Status { get; set; }
        public int? Vorgangsnummer { get; set; }
        public string Kundennummer { get; set; }
        public string Kundenname { get; set; }
        public int? AuftragsJahr { get; set; }
        public int? Auftragsnummer { get; set; }
        public int? LieferscheinJahr { get; set; }
        public int? Lieferscheinnummer { get; set; }
        public string Referenznummer { get; set; }
        public DateTime? Belegdatum { get; set; }
        public DateTime? ReklamationsSystemDatum { get; set; }
        public DateTime? ReklamationsKundeDatum { get; set; }
        public string Stornorechnungsnummer { get; set; }
        public string RVEStornorechnung { get; set; }
        public string RVENummer { get; set; }
        public string AB_StornoBelNum { get; set; }
        public string LF_RuckBelNum { get; set; }
        public string RVEAB_StornoBelNum { get; set; }
        public string RVELF_RuckBelNum { get; set; }
        public int? RechnungsJahr { get; set; }
        public int? Rechnungsnummer { get; set; }
        public string GutschriftNummer { get; set; }
        public string AbholeFirma { get; set; }
        public string Abholenummer { get; set; }
        public DateTime? Abholetermin { get; set; }
        public decimal? Versandkosten { get; set; }
        public int? WiedereinlagerungGebühr { get; set; }
        public string WeitereNotizen { get; set; }
        public DateTime? Ablehnungsdatum { get; set; }
        public string Ersteller { get; set; }
        public DateTime? Erstelldatum { get; set; }
        public string Updater { get; set; }
        public DateTime? Updatedatum { get; set; }
        public string ProdStatu { get; set; }
        public string ProdText { get; set; }
        public string Temp { get; set; }
        public int? Web_ID { get; set; }
        public string Email { get; set; }

        public ICollection<KTrkl_Positionen> Positionens { get; set; }
        public ICollection<KTrkl_Bild> Bilds { get; set; }

        [NotMapped]
        public string selectedRow { get; set; } = "";

        [NotMapped]
        public string statusmessage { get; set; }

        [NotMapped]
        public int UnReadMessages { get; set; }
    }
}
