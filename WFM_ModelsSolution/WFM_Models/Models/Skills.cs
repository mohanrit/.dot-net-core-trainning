
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WFM_Models.Models
{
    public class Skills
    {
        [Key]
        public int skillid { get; set; }
        public string name { get; set; }
    }
}
