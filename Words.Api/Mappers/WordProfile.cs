using AutoMapper;
using Words.Api.Model;
using Words.Model.Entities;
using Words.Model.Filters;

namespace Words.Api.Mappers
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordFilterDto, WordFilter>();
            CreateMap<Word, WordDto>();
        }
    }
}
