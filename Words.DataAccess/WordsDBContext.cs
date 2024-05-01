using Microsoft.EntityFrameworkCore;
using Words.Model.Entities;

namespace Words.DataAccess
{
    public class WordsDBContext(DbContextOptions<WordsDBContext> options) : DbContext(options)
    {
        public virtual DbSet<Word> Word { get; set; }

    }
}
