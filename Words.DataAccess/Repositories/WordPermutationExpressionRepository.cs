using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;

namespace Words.DataAccess.Repositories
{
    public class WordPermutationExpressionRepository(WordsDBContext dBContext) : IWordPermutationExpressionRepository
    {
        private readonly WordsDBContext _dbContext = dBContext;

        public WordPermutationExpression? GetById(int id)
        {
            return _dbContext.WordPermutationExpression.Find(id);
        }

        public IEnumerable<WordPermutationExpression> GetByRegExp(WordPermutationExpression expression)
        {
            return [.. _dbContext
                .WordPermutationExpression
                .Where(word => 
                    word.WordSimpleValue.Length <= expression.WordSimpleValue.Length 
                    && word.LettersSet.Length <= expression.LettersSet.Length 
                    && word.LettersSetOcurrences <= expression.LettersSetOcurrences
                )];
        }
    }
}
