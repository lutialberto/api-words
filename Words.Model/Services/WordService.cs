﻿using Words.Model.Entities;
using Words.Model.Filters;
using Words.Model.Repositories;
using Words.Model.Utils;

namespace Words.Model.Services
{
    public class WordService: IWordService
    {
        readonly IWordRepository _wordRepository;
        public WordService(
            IWordRepository wordRepository
        )
        {
            _wordRepository = wordRepository;
        }

        public IEnumerable<Word> GetAll()
        {
            return _wordRepository.GetAll();
        }

        public IEnumerable<Word> GetByFilter(PaginationFilter pagination, WordFilter filter)
        {
            var query = _wordRepository.GetByFilter(filter);
            return PaginationHelper.ApplyPagination(query,pagination);
        }
    }
}
