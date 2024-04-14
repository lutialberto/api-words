using AutoMapper;
using Words.Api.Model;
using Words.Model.Filters;

namespace Words.Api.Mappers
{
    public class PaginationProfile: Profile
    {
        public PaginationProfile()
        {
            CreateMap<PaginationFilterDto, PaginationFilter>();
        }
    }
}
