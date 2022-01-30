using Microsoft.EntityFrameworkCore;
using Reklamation.Models;
using Reklamation.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
      
        public DbSet<KTrkl_Reklamation> _Reklamations { get; set; }
        public DbSet<KTrkl_Positionen> _Positionens { get; set; }
        public DbSet<KTrkl_Bild> _Bilds { get; set; }
        public DbSet<BelegeDTO> Beleges { get; set; }
        public DbSet<BelegPosDTO> BelegPosList { get; set; }
        public DbSet<KTrkl_TxtGrund> TxtGrunds { get; set; }
        public DbSet<StatusFehler> StatusFehler { get; set; }
        public DbSet<KTEnumerator> KTEnumerators { get; set; }
        public DbSet<FunctionCheckDTO> FunctionCheck { get; set; }
        public DbSet<KTrkl_Message> KTrkl_MessagesDbSet { get; set; }

        [DbFunction("KTrkl_StatuFertigCheck", "dbo")]
        public static string CheckStatus(int Rek_ID)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KTrkl_Reklamation>()
                .HasMany(r => r.Positionens)
                .WithOne(m => m.Reklamation)
                .HasForeignKey(m => m.Rek_ID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<KTrkl_Reklamation>()
                .HasMany(r => r.Bilds)
                .WithOne(m => m.Reklamation)
                .HasForeignKey(m => m.Rek_ID)
                .IsRequired();

            modelBuilder.Entity<KTrkl_Message>()
                .HasKey(x => new { x.Web_ID, x.Datum });
        }
    }
}
