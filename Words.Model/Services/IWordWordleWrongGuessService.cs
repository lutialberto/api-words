using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Services
{
    public interface IWordWordleWrongGuessService
    {
        public void SaveWrongGuess(string word);
    }
}
