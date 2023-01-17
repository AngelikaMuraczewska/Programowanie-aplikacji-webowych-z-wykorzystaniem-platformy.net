using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRapp.Pages.Models;

namespace HRapp.Data
{
    public class HRappContext : DbContext
    {
        public HRappContext (DbContextOptions<HRappContext> options)
            : base(options)
        {
        }

        public DbSet<HRapp.Pages.Models.Employee> Employee { get; set; } = default!;
    }
}
