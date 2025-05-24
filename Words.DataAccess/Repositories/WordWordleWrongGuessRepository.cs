using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordWordleWrongGuessRepository(WordsDBContext dBContext) : IWordWordleWrongGuessRepository
    {
        private readonly WordsDBContext _dbContext = dBContext;

        public void SaveWrongGuess(string word)
        {
            var guess = _dbContext.WordWordleWrongGuess.Where(x => x.Word == word).FirstOrDefault();
            if(guess != null)
            {
                guess.Quantity++;
                guess.LastWrongGuessDate = DateTime.UtcNow;

				_dbContext.WordWordleWrongGuess.Update(guess);
            }
            else
            {
                _dbContext.WordWordleWrongGuess.Add(new WordWordleWrongGuess
                {
                    Word = word,
                    Quantity = 1
                });
            }
             _dbContext.SaveChanges();
        }
    }
}
