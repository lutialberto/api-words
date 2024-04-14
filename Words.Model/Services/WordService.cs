using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;

namespace Words.Model.Services
{
    public class WordService: IWordService
    {
        readonly IWordRepository _wordRepository;
        public WordService(
            IWordRepository wordRepository
        )
        {
            _wordRepository = wordRepository;
        }

        public IEnumerable<Word> GetAll()
        {
            return _wordRepository.GetAll();
        }

        public IEnumerable<Word> GetByFilter(WordFilter filter)
        {
            return _wordRepository.GetByFilter(filter);
        }
    }
}
