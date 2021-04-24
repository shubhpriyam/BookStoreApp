using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Contracts.Models;


namespace BookStoreApp.Repository.DataAccess.SQL.Context
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opt) : base(opt)
        {

        }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<LoginAdminModel> loginAdminModels { get; set; }
    }
}
