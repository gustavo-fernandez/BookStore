using DataAccess.Model;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("name=BookStoreCS") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
