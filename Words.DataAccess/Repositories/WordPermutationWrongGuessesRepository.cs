using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordPermutationWrongGuessesRepository(WordsDBContext dBContext) : IWordPermutationWrongGuessesRepository
    {
        private readonly WordsDBContext _dbContext = dBContext;

        public void SaveWrongGuesses(WordPermutationWrongGuesses wordPermutationWrongGuesses)
        {
            _dbContext.WordPermutationWrongGuesses.Add(wordPermutationWrongGuesses);
            _dbContext.SaveChangesAsync();
        }
    }
}
