using Microsoft.EntityFrameworkCore;
using Words.Model.Entities;

namespace Words.DataAccess
{
    public class WordsDBContext : DbContext
    {
        public WordsDBContext(DbContextOptions<WordsDBContext> options) : base(options) { }

        public virtual DbSet<Word> Word { get; set; }

    }
}
