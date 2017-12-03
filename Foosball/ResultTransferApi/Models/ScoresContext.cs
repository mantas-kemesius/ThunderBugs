using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ResultTransferApi.Models
{
    public class ScoresContext : DbContext
    {
        public ScoresContext(DbContextOptions<ScoresContext> options)
            : base(options)
        {
        }

        public DbSet<Scores> Scores { get; set; }
    }
}
