using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models
{
    [Keyless]
    public class StatusFehler
    {
        public string message { get; set; }
    }
}
