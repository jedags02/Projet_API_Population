using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Pays
    {
       
            public int id { get; set; }
            public String nomPays { get; set; }
            public Continent continent { get; set; }
            public List<Population> LaPopulation { get; set; }

    }
}
