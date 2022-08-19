using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Commutators.Models.Entities;

namespace Commutators.Data
{
    public class CommutatorsContext : DbContext
    {
        public CommutatorsContext (DbContextOptions<CommutatorsContext> options)
            : base(options)
        {
        }

        public DbSet<Commutators.Models.Entities.BaseCommutator> BaseCommutator { get; set; } = default!;
    }
}
