using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    public class MessagePostDto
    {
        public int Web_ID { get; set; }
        public DateTime Datum { get; set; }
        public string MUser { get; set; }
        public string Message { get; set; }
        public string Kundenname { get; set; }
        public string Email { get; set; }
    }
}
