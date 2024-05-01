using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordRepository(WordsDBContext dBContext) : IWordRepository
    {
        private readonly WordsDBContext _dbContext = dBContext;

        public IEnumerable<Word> GetAll()
        {
            return _dbContext.Word;
        }

        public IEnumerable<Word> GetByFilter(WordFilter filter)
        {
            return _dbContext
                .Word
                .Where(word => 
                    (!filter.Length.HasValue || word.Value.Length == filter.Length)
                    && (string.IsNullOrEmpty(filter.Value) || word.Value == filter.Value)
                    && (string.IsNullOrEmpty(filter.SimpleValue) || word.SimpleValue == filter.SimpleValue)
                    && (string.IsNullOrEmpty(filter.Substring) || word.SimpleValue.Contains(filter.Substring))
                )
            ;
        }
    }
}
