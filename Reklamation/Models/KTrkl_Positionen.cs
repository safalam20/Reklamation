using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
    [Table("KTrkl_Positionen")]
    public class KTrkl_Positionen
    {
        [Key]
        public int Pos_ID { get; set; }
        public int? Rek_ID { get; set; }
        public short? Mandant { get; set; }
        public int? BelID { get; set; }
        public int? BelPosID { get; set; }
        public string ArtGruppe { get; set; }
        public string ArtikelGruppe { get; set; }
        public string Artikelnummer { get; set; }
        //public string GrundKunde { get; set; }
        //public string GrundUnserer { get; set; }

        public int? GrundK_ID { get; set; }
        public int? GrundU_ID { get; set; }
        public string HatKundeRecht { get; set; }
        public string Bemerkung { get; set; }
        public int? ProduktionsJahr { get; set; }
        public string ProduktionsbatchDatum { get; set; }
        public string SerialNoSerienNr { get; set; }
        public string Hersteller { get; set; }
        public string DotWocheJahr { get; set; }
        public string RestProfiltiefe { get; set; }
        public int? KMGefahren { get; set; }
        public int? Menge { get; set; }
        public string Bezeichnung1 { get; set; }
        public string PrFehler { get; set; }
        public string ErgebnisWare { get; set; }
        public int? gesMenge { get; set; }
        public string gesArtikelnummer { get; set; }

        public virtual KTrkl_Reklamation Reklamation { get; set; }

        [NotMapped]
        public bool isProFehler
        {
            get
            {
                if (PrFehler == "1") { return true; }
                else { return false; }
            }
            set
            {
                if (value) { PrFehler = "1"; }
                else { PrFehler = null; }
            }
        }
    }
}
