using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace JobApplicationApi.Models
{
    public partial class APICoreDBContext : DbContext
    {
        public APICoreDBContext()
        {
        }
        public APICoreDBContext(DbContextOptions<APICoreDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=DESKTOP-SCG5HFM\\SQLSERVER2017; Database=APICoreDB; User ID=sa;Password=alita1010;");
            //            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.POB)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.FilePath)
                 .HasMaxLength(256)
                 .IsUnicode(false);

                entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false);



            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
