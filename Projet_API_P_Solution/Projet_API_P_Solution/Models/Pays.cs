using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_Solution.Models
{
    public class Pays
    {
       
            public int Id { get; set; }
            public String nomPays { get; set; }
            [ForeignKey("FK_Continent_Pays")]
            public int ContinentID { get; set; }
            public ICollection<Population> Populations { get; set; }

            public Pays()
            {
                Populations = new List<Population>();
            }

    }
}
