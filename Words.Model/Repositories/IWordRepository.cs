using Words.Model.Entities;
using Words.Model.Filters;

namespace Words.Model.Repositories
{
    public interface IWordRepository
    {
        public IEnumerable<Word> GetAll();
        public IEnumerable<Word> GetByFilter(WordFilter filter);
    }
}
