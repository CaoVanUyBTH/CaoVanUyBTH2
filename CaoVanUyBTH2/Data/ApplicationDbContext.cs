using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaoVanUyBTH2.Models;

    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext (DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        public DbSet<CaoVanUyBTH2.Models.Employee> Employee { get; set; } = default!;

        public DbSet<CaoVanUyBTH2.Models.Student>? Student { get; set; }

        public DbSet<CaoVanUyBTH2.Models.Person>? Person { get; set; }

        public DbSet<CaoVanUyBTH2.Models.Customer>? Customer { get; set; }
    }