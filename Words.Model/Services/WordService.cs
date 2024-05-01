using System.Linq;
using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;
using Words.Model.Utils;

namespace Words.Model.Services
{
    public class WordService(
        IWordRepository wordRepository
        ) : IWordService
    {
        readonly IWordRepository _wordRepository = wordRepository;

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
            var query = _wordRepository.GetByFilter(new WordFilter
            {
                Length = filter.Length,
                Substring = filter.Substring
            });

            if(query == null || !query.Any())
            {
                throw new Exception("Do not exists a word for the given criteria");
            }
            var randomIndex = new Random().Next(0, query.Count());
            var wordToSplit = query.ElementAt(randomIndex).SimpleValue;

            var letters = wordToSplit.ToCharArray();
            var permutations = GetSubWordsFromLetters(letters);
            return new WordPermutations
            {
                Letters = letters,
                Permutations = permutations,
            };
        }

        private HashSet<string> GetSubWordsFromLetters(char[] letters)
        {
            if (letters.Length == 0) return [];
            HashSet<string> result = [];
            var query = _wordRepository.GetByFilter(new WordFilter
            {
                Length = letters.Length,
            }).ToList();

            foreach (var word in query.Where(e => letters.All(letter => e.SimpleValue.Contains(letter))))
            {
                if(word.SimpleValue.ToCharArray().All(l => letters.Contains(l)))
                {
                    result.Add(word.SimpleValue);
                }
            }

            for (int i = 0; i < letters.Length; i++)
            {
                char[] slice0 = letters.Take(i)?.ToArray() ?? [];
                char[] slice1 = letters.Skip(i+1)?.ToArray() ?? [];
                char[] newArray = [.. slice0, .. slice1];
                var subResult = GetSubWordsFromLetters(newArray);
                result.Concat(subResult);
            }

            return result;
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
