using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordTabooCardRepository(WordsDBContext dBContext) : IWordTabooCardRepository
    {
        private readonly WordsDBContext _dbContext = dBContext;

        public WordTabooCard GetWordTabooCard(List<int> wordIdsToExclude)
        {
            var results = _dbContext.WordTabooCard.Where(x => !wordIdsToExclude.Contains(x.Id));
            var rnd = new Random();
            var index = rnd.Next(0,results.Count());
            return results.ElementAt(index);
        }
    }
}
