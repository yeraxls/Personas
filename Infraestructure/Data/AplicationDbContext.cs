using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
