using Microsoft.EntityFrameworkCore;
using tz.Models;

namespace tz
{
    public class FoldersContext : DbContext
    {
        public FoldersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Folder> Folders { get; set; }
    }
}
