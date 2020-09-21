using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreWpfApp.AppDB
{
    public partial class projectappdbContext : DbContext
    {
        public projectappdbContext()
        {
        }

        public projectappdbContext(DbContextOptions<projectappdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pril11RegionIdHcpCvCs> Pril11RegionIdHcpCvCs { get; set; }
        public virtual DbSet<Pril2NPlessPaboveMrGamma> Pril2NPlessPaboveMrGamma { get; set; }
        public virtual DbSet<Table10ZiPsyi> Table10ZiPsyi { get; set; }
        public virtual DbSet<Table11ZiVodonepronitsaemie> Table11ZiVodonepronitsaemie { get; set; }
        public virtual DbSet<Table12SloyTalikhVod> Table12SloyTalikhVod { get; set; }
        public virtual DbSet<Table13RTau> Table13RTau { get; set; }
        public virtual DbSet<Table14HPlim> Table14HPlim { get; set; }
        public virtual DbSet<Table15K1PlimCN> Table15K1PlimCN { get; set; }
        public virtual DbSet<Table16K2PlimC> Table16K2PlimC { get; set; }
        public virtual DbSet<Table9K> Table9K { get; set; }
        public virtual DbSet<Regulations> Regulations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=Atomic2w@;database=projectappdb", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pril11RegionIdHcpCvCs>(entity =>
            {
                entity.HasKey(e => e.RegionName)
                    .HasName("PRIMARY");

                entity.ToTable("pril11_region_id_hcp_cv_cs");

                entity.Property(e => e.RegionName)
                    .HasColumnName("regionName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CS)
                    .HasColumnName("c_s")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.CV)
                    .HasColumnName("c_v")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Havg).HasColumnType("decimal(6,3)");

                entity.Property(e => e.ReionId)
                    .HasColumnName("reionId")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Pril2NPlessPaboveMrGamma>(entity =>
            {
                entity.HasKey(e => e.Region)
                    .HasName("PRIMARY");

                entity.ToTable("pril2_n_pless_pabove_mr_gamma");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gamma)
                    .HasColumnName("gamma")
                    .HasColumnType("decimal(3,2)");

                entity.Property(e => e.Mr).HasColumnName("mr");

                entity.Property(e => e.NPabove1)
                    .HasColumnName("n_pabove1")
                    .HasColumnType("decimal(3,2)");

                entity.Property(e => e.NPless1)
                    .HasColumnName("n_pless1")
                    .HasColumnType("decimal(3,2)");
            });

            modelBuilder.Entity<Table10ZiPsyi>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("table10_zi_psyi");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PsyI)
                    .HasColumnName("psy_i")
                    .HasColumnType("decimal(7,3)");

                entity.Property(e => e.ZI)
                    .HasColumnName("z_i")
                    .HasColumnType("decimal(7,3)");
            });

            modelBuilder.Entity<Table11ZiVodonepronitsaemie>(entity =>
            {
                entity.HasKey(e => e.A)
                    .HasName("PRIMARY");

                entity.ToTable("table11_zi_vodonepronitsaemie");

                entity.Property(e => e.A).HasColumnName("a");

                entity.Property(e => e.NAbove065)
                    .HasColumnName("nAbove065")
                    .HasColumnType("decimal(7,3)");

                entity.Property(e => e.NLess065)
                    .HasColumnName("nLess065")
                    .HasColumnType("decimal(7,3)");
            });

            modelBuilder.Entity<Table12SloyTalikhVod>(entity =>
            {
                entity.HasKey(e => e.ClimateId)
                    .HasName("PRIMARY");

                entity.ToTable("table12_sloy_talikh_vod");

                entity.Property(e => e.ClimateId).HasColumnName("climateId");

                entity.Property(e => e.P0022).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P0033).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P005).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P010).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P015).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P045).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P095).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P328).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P495).HasColumnType("decimal(6,2)");

                entity.Property(e => e.P995).HasColumnType("decimal(6,2)");
            });

            modelBuilder.Entity<Table13RTau>(entity =>
            {
                entity.HasKey(e => e.C)
                    .HasName("PRIMARY");

                entity.ToTable("table13_r_tau");

                entity.Property(e => e.C)
                    .HasColumnName("c")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Tau)
                    .HasColumnName("tau")
                    .HasColumnType("decimal(6,3)");
            });

            modelBuilder.Entity<Table14HPlim>(entity =>
            {
                entity.ToTable("table14_h_plim");

                entity.Property(e => e.HRain)
                    .IsRequired()
                    .HasColumnName("h_rain")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Plim).HasColumnType("decimal(7,3)");
            });

            modelBuilder.Entity<Table15K1PlimCN>(entity =>
            {
                entity.HasKey(e => e.Plim)
                    .HasName("PRIMARY");

                entity.ToTable("table15_k1_plim_c_n");

                entity.Property(e => e.Plim).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C085nAbove07).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C085nLess07).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C100nAbove07).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C100nLess07).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C120nAbove07).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C120nLess07).HasColumnType("decimal(6,3)");
            });

            modelBuilder.Entity<Table16K2PlimC>(entity =>
            {
                entity.HasKey(e => e.P)
                    .HasName("PRIMARY");

                entity.ToTable("table16_k2_plim_c");

                entity.Property(e => e.P).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C085).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C100).HasColumnType("decimal(6,3)");

                entity.Property(e => e.C120).HasColumnType("decimal(6,3)");
            });

            modelBuilder.Entity<Table9K>(entity =>
            {
                entity.HasKey(e => e.F)
                    .HasName("PRIMARY");

                entity.ToTable("table_9_k");

                entity.Property(e => e.K)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
