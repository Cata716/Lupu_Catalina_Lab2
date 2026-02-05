using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lupu_Catalina_Lab2.Models;

namespace Lupu_Catalina_Lab2.Data
{
    public class Lupu_Catalina_Lab2Context : DbContext
    {
        public Lupu_Catalina_Lab2Context (DbContextOptions<Lupu_Catalina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lupu_Catalina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Lupu_Catalina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Lupu_Catalina_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Lupu_Catalina_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Lupu_Catalina_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Lupu_Catalina_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
