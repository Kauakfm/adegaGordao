using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebApiGordao.Repository.Models;

namespace WebApiGordao.Repository
{
    public class GordaoEntities : DbContext
    {

        public GordaoEntities(DbContextOptions<GordaoEntities> options) : base(options) { }

        public DbSet<tabProdutos> tabProdutos { get; set; }
        public DbSet<tabTiposProdutos> tabTiposProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabProdutos>().ToTable("tabProdutos");
            modelBuilder.Entity<tabTiposProdutos>().ToTable("tabTiposProdutos");
        }
    }
}

