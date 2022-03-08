using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet_API_P_Solution.Models;

namespace Projet_API_P_Solution.Data
{
    public class Projet_API_P_SolutionContext : DbContext
    {
        public Projet_API_P_SolutionContext (DbContextOptions<Projet_API_P_SolutionContext> options)
            : base(options)
        {
        }

        public DbSet<Projet_API_P_Solution.Models.Population> Population { get; set; }

        public DbSet<Projet_API_P_Solution.Models.Pays> Pays { get; set; }
        public object Continent { get; internal set; }
    }
}
