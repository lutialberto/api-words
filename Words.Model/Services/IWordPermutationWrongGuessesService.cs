using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Services
{
    public interface IWordPermutationWrongGuessesService
    {
        public void SaveWrongGuesses(string[] wrongGuesses, char[] letters);
    }
}
