using Microsoft.EntityFrameworkCore;
using Occupation_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occupation_proj.Context
{
    public class OccupationDetailContext: DbContext
        {
            public OccupationDetailContext(DbContextOptions<OccupationDetailContext> options) : base(options)
            {
            }
            public DbSet<OccupationDetail> OccupationDetails { get; set; }
        }
    
}
