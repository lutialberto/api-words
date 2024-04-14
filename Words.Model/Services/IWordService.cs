using Words.Model.Entities;
using Words.Model.Filters;

namespace Words.Model.Services
{
    public interface IWordService
    {
        public IEnumerable<Word> GetAll();
        public IEnumerable<Word> GetByFilter(PaginationFilter pagination, WordFilter filter);
        public Word? GetRandomWord(WordFilter filter);
    }
}
