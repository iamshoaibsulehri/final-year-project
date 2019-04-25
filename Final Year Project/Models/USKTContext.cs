using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Models
{
    public partial class USKTContext : DbContext
    {
        public USKTContext()
        {
        }

        public USKTContext(DbContextOptions<USKTContext> options)
            : base(options)
        {
        }


        public virtual DbSet<FacultyProfile> FacultyProfile { get; set; }
        public virtual DbSet<NewsLetterr> NewsLetterr { get; set; }
        public virtual DbSet<Registeration> Registeration { get; set; }
        public virtual DbSet<TimeTableManagemnet> TimeTableManagemnet { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //  {
        //    if (!optionsBuilder.IsConfigured)
          //  {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseSqlServer("Server=DESKTOP-S88RNC4\\SQLEXPRESS;DataBase=USKT;Trusted_Connection=True; User ID=sa; Password=ahsan;");
    //        }
      //  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacultyProfile>(entity =>
            {
                entity.ToTable("Faculty_Profile");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("Profile_Picture")
                    .HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.University).HasMaxLength(50);
            });

            modelBuilder.Entity<NewsLetterr>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Registeration>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
               

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<TimeTableManagemnet>(entity =>
            {
                entity.Property(e => e.Program).HasMaxLength(50);

                entity.Property(e => e.Section).HasMaxLength(50);

                entity.Property(e => e.TimeTable).HasMaxLength(50);
            });
        }
    }
}
