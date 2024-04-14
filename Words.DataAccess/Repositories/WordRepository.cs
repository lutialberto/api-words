using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly WordsDBContext _dbContext;
        public WordRepository(WordsDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Word> GetAll()
        {
            return _dbContext.Word;
        }

        public IEnumerable<Word> GetByFilter(WordFilter filter)
        {
            return _dbContext
                .Word
                .Where(word => (
                    !filter.Length.HasValue || word.Value.Length == filter.Length
                ))
                ;
        }
    }
}
