using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
    [Table("KTrkl_Bild")]
    public class KTrkl_Bild
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Bld_ID { get; set; }
       public int? Rek_ID { get; set; }
       public string Name { get; set; }
       public string Bild { get; set; }
       public string BildPath { get; set; }

       public virtual KTrkl_Reklamation Reklamation { get; set; }
    }
}
