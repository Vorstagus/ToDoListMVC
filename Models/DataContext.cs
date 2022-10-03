using Microsoft.EntityFrameworkCore;

namespace ToDoListMVC.Models
{



    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {

                options.UseMySQL("Connection String....");

            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

        }
        //Gets or sets the collection that contains UserModel entities

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RecordModel> Records { get; set; }

    
    }
}
