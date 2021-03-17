using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Models
{
    public class Login
    {
        public int id { get; set; }

        public string email { get; set; }

        public string senha { get; set; }
    }
}
