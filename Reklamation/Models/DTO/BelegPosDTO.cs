using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    [Keyless]
    public class BelegPosDTO
    {
        public string Position { get; set; }
        public int BelPosID { get; set; }
        public short Mandant { get; set; } 
	    public int BelID { get; set; }
        public decimal? Menge { get; set; } 
	    public string USER_Artikelgruppe { get; set; } 
	    public string Artikelnummer { get; set; }

        [NotMapped]
        public bool isSelected { get; set; }

        [NotMapped]
       public int? _Menge
        {
            get
            {
                return Decimal.ToInt32((decimal)Menge);
            }
            set
            {
                Menge = Convert.ToDecimal(value);
            }
        }

        public int? RekMenge { get; set; }

        [NotMapped]
        public int? NeuReklamationMenge { get; set; }
    }
}
