using Words.Model.Entities;
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
            return _dbContext.Word.ToList();
        }
    }
}
