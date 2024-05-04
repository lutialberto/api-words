using System.Linq;
using System.Text.RegularExpressions;
using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;
using Words.Model.Utils;

namespace Words.Model.Services
{
    public class WordService(
        IWordRepository wordRepository,
        IWordPermutationExpressionRepository wordPermutationExpressionRepository
        ) : IWordService
    {
        readonly IWordRepository _wordRepository = wordRepository;
        readonly IWordPermutationExpressionRepository _wordPermutationExpressionRepository = wordPermutationExpressionRepository;

        public IEnumerable<Word> GetAll()
        {
            return _wordRepository.GetAll();
        }

        public IEnumerable<Word> GetByFilter(PaginationFilter pagination, WordFilter filter)
        {
            var query = _wordRepository.GetByFilter(filter);
            return PaginationHelper.ApplyPagination(query,pagination);
        }

        public WordPermutations GetPermutations(WordPermutationsFilter filter)
        {
            var wordToSplit = GetWordToSplitIntoLetters(filter);

            var wordPermutationRegExp = _wordPermutationExpressionRepository.GetById(wordToSplit.Id) ?? throw new Exception("Do not exists a word permutation regexp for the given word" + wordToSplit.Value);

            var letters = wordToSplit.SimpleValue.ToCharArray();
            var result = _wordPermutationExpressionRepository.GetByRegExp(wordPermutationRegExp);
            var permutations = result
                .Where(word => Regex.IsMatch(word.LettersSorted, wordPermutationRegExp.PermutationRegExp))
                .Select(e => e.WordSimpleValue)
                .OrderByDescending(e => e.Length);

            return new WordPermutations
            {
                Letters = letters,
                Permutations = permutations,
            };
        }

        private Word GetWordToSplitIntoLetters(WordPermutationsFilter filter)
        {
            var query = _wordRepository.GetByFilter(new WordFilter
            {
                Length = filter.Length,
            });

            if (query == null || !query.Any())
            {
                throw new Exception("Do not exists a word for the given criteria");
            }
            var randomIndex = new Random().Next(0, query.Count());
            var wordToSplit = query.ElementAt(randomIndex);
            return wordToSplit;
        }

        public Word? GetRandomWord(WordFilter filter)
        {
            var query = _wordRepository.GetByFilter(filter);
            var randomizer = new Random();
            if(query?.Count() > 0)
            {
                var index = randomizer.Next(query.Count() -1);
                return query.ElementAt(index);
            }
            return null;
        }
    }
}
