using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TMT_USRAUT_ENG
    {
            [Key]
            public int id { get; set; }
            public string usuario { get; set; }
            public string unidad { get; set; }
        
    }
}
