using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;

namespace Words.Model.Repositories
{
    public interface IWordPermutationWrongGuessesRepository
    {
        public void SaveWrongGuesses(WordPermutationWrongGuesses wordPermutationWrongGuesses);
    }
}
