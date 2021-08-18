//using DAL.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {

        public SolutionDbContext(DbContextOptions<SolutionDbContext> options): base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
