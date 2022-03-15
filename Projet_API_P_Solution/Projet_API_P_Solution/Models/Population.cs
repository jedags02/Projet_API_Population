using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Population
    {
        public int Id { get; set; }
        public ulong nbrPopulation { get; set; }
        public int annee { get; set; }

        [ForeignKey("FK_Pays_Population")]
        public int PaysID { get; set; }
    }
}
