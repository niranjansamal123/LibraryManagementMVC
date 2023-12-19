using System.Data.Entity;

namespace LibraryManagementMVC.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("ConStr")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryDbContext>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}