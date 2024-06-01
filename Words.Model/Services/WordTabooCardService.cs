using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.Model.Services
{
    public class WordTabooCardService(
        IWordTabooCardRepository repository
        ) : IWordTabooCardService
    {
        public WordTabooCard GetWordTabooCard(List<int> wordIdsToExclude)
        {
            return repository.GetWordTabooCard(wordIdsToExclude);
        }
    }
}
