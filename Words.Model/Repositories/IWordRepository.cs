using Words.Model.Entities;

namespace Words.Model.Repositories
{
    public interface IWordRepository
    {
        public IEnumerable<Word> GetAll();
    }
}
