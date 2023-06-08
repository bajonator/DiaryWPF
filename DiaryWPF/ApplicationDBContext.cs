using DiaryWPF.Models.Configurations;
using DiaryWPF.Models.Domains;
using DiaryWPF.Properties;
using System;
using System.Data.Entity;
using System.Linq;

namespace DiaryWPF
{
    public class ApplicationDBContext : DbContext
    {
        private static string _connectionString =
            $@"Server={Settings.Default.AdressServer}\{Settings.Default.NameServer};Database={Settings.Default.DatabaseName};User Id={Settings.Default.User};Password={Settings.Default.Password};";

        public ApplicationDBContext()
            : base(_connectionString)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguraton());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
        }
    }
}