using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Population
    {
        public int id { get; set; }
        public ulong nbrPopulation { get; set; }
        public Pays  pays { get; set; }
        public int annee { get; set; }
    }
}
