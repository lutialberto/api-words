using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Words.Model.Entities;

namespace Words.Model.Repositories
{
    public interface IWordPermutationExpressionRepository
    {
        public WordPermutationExpression? GetById(int id);
        public IEnumerable<WordPermutationExpression> GetByRegExp(WordPermutationExpression expression);
    }
}
