using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Repositories;

namespace Words.Model.Services
{
    public class WordPermutationWrongGuessesService(
        IWordPermutationWrongGuessesRepository wordPermutationWrongGuesses
        ) : IWordPermutationWrongGuessesService
    {
        public void SaveWrongGuesses(string[] wrongGuesses, char[] letters)
        {
            wordPermutationWrongGuesses.SaveWrongGuesses(new WordPermutationWrongGuesses
                {
                    WrongGuesses = string.Join(',', wrongGuesses),
                    Letters = string.Join(',', letters),
                }
            );
        }
    }
}
