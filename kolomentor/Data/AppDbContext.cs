using kolomentor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kolomentor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnectionStrings");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientCascade;
            }
            // Mentor Resource Relationship
            modelBuilder.Entity<Mentor_Material>().HasKey(mr => new
            {
                mr.MentorId,
                mr.MaterialId
            });
            modelBuilder.Entity<Mentor>().HasOne(i => i.Career).WithMany(c => c.Mentors).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Mentor>().HasOne(i => i.Career).WithMany(c => c.Mentors).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mentor_Material>().HasOne(m => m.Mentor).WithMany(mr => mr.Mentors_Materials).HasForeignKey(mr => mr.MentorId);
            modelBuilder.Entity<Mentor_Material>().HasOne(m => m.Material).WithMany(mr => mr.Mentors_Materials).HasForeignKey(mr => mr.MaterialId);


            modelBuilder.Entity<Mentee>().HasOne(m => m.Mentor).WithMany(me => me.Mentees).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Mentee>().HasOne(m => m.Mentor).WithMany(me => me.Mentees).IsRequired().OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        internal Task UpdateAsync(Career newcareer)
        {
            throw new NotImplementedException();
        }

        public DbSet<Career> Careers { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Mentee> Mentees { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Mentor_Material> Mentors_Materials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MentorMenteeModel> MentorsMentees { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<SkillTypeTopic> SkillTypeTopics { get; set; }
    }
}
