using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.Model.Services
{
    public class WordWordleWrongGuessService(
        IWordWordleWrongGuessRepository repository
        ) : IWordWordleWrongGuessService
    {
        public void SaveWrongGuess(string word)
        {
            repository.SaveWrongGuess(word);
        }
    }
}
