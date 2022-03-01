using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Continent
    {
        public int id { get; set; }
        public string nom { get; set; }

        public List<Pays> LesPays { get; set; } 

    }
}
