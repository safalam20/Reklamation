using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    public class FilterListDTO
    {
        public bool isStored { get; set; }
        public string searchTerm { get; set; }
        public string searchStatus { get; set; }
    }
}
