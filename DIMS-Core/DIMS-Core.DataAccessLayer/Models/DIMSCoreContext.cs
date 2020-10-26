using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class DIMSCoreContext : DbContext
    {
        public DIMSCoreContext()
        {
        }

        public DIMSCoreContext(DbContextOptions<DIMSCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<VUserProfile> VUserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DIMSCore;User Id=sa;Password=Barrow2013");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C01393682");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserProfi__Direc__38996AB5");
            });

            modelBuilder.Entity<VUserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProfile");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
