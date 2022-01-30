using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
	[Table("KTrkl_TxtGrund")]
	public class KTrkl_TxtGrund
    {
		[Key]
		public int Grund_ID { get; set; }
		public string Grund { get; set; }
		public string ArtGruppe { get; set; }
		public string HatRecht { get; set; }
		public int? Grup1 { get; set; }
		public int? Grup2 { get; set; }
    }
}
