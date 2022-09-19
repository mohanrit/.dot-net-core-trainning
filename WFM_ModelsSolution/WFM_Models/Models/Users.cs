using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFM_Models.Models
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }

        public string name { get; set; }

        public string role { get; set; }
        public string email { get; set; }
    }
}
