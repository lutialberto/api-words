using Microsoft.EntityFrameworkCore;
using Words.Model.Entities;

namespace Words.DataAccess
{
    public class WordsDBContext(DbContextOptions<WordsDBContext> options) : DbContext(options)
    {
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordPermutationExpression> WordPermutationExpression { get; set; }
        public virtual DbSet<WordPermutationWrongGuesses> WordPermutationWrongGuesses { get; set; }
        public virtual DbSet<WordWordleWrongGuess> WordWordleWrongGuess { get; set; }
        public virtual DbSet<WordTabooCard> WordTabooCard { get; set; }
    }
}
