using AutoMapper;
using Words.Api.Model;
using Words.Model.Entities;

namespace Words.Api.Mappers
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordDto>();
        }
    }
}
