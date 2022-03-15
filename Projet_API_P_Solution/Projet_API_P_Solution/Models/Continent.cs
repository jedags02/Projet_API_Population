using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public String nomContinent { get; set; }
        
        public ICollection<Pays> Pays { get; set; }

        public Continent()
        {
            Pays = new List<Pays>();
        }
    }
}
