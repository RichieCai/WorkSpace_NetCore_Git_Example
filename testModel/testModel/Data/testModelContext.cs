#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testModel.Models;

namespace testModel.Data
{
    public class testModelContext : DbContext
    {
        public testModelContext (DbContextOptions<testModelContext> options)
            : base(options)
        {
        }

        public DbSet<testModel.Models.Show> Show { get; set; }
    }
}
