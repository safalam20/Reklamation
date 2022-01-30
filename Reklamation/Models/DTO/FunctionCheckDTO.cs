using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Models.DTO
{
    [Keyless]
    public class FunctionCheckDTO
    {
        public int CheckCount { get; set;}
    }
}
