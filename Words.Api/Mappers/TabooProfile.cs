using AutoMapper;
using Words.Api.Model;
using Words.Model.Entities;
using Words.Model.Filters;

namespace Words.Api.Mappers
{
    public class TabooProfile : Profile
    {
        public TabooProfile()
        {
            CreateMap<WordTabooCard, WordTabooCardDto>()
                .ForMember(x => x.UnmentionableWords, cd => cd.MapFrom(map => map.UnmentionableWords.Split(new char[]{','})))
            ;
        }
    }
}
