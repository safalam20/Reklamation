using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
    [Table("KTrkl_Message")]
    public class KTrkl_Message
    {
        public int Web_ID { get; set; }
        public DateTime Datum { get; set; }
        public string MUSER { get; set; }
        public string MType { get; set; }
        public string Message { get; set; }
        public int isRead { get; set; }
    }
}
