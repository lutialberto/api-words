using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Words.Api.Model;
using Words.Model.Filters;
using Words.Model.Services;

namespace Words.Api.Controllers
{
    [ApiController]
    [Route("words")]
    public class WordsController(
        ILogger<WordsController> logger,
        IWordService wordService,
        IMapper mapper
        ) : ControllerBase
    {
        private readonly ILogger<WordsController> _logger = logger;
        private readonly IWordService _wordService = wordService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IEnumerable<WordDto> Get([FromQuery] PaginationFilterDto paginationDto, [FromQuery] WordFilterDto filterDto)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationDto);
            var filter = _mapper.Map<WordFilter>(filterDto);
            var words = _wordService.GetByFilter(pagination, filter);
            return _mapper.Map<IEnumerable<WordDto>>(words);
        }


        [HttpGet("random")]
        public WordDto GetRandomWord([FromQuery] WordFilterDto filterDto)
        {
            var filter = _mapper.Map<WordFilter>(filterDto);
            var randomWord = _wordService.GetRandomWord(filter);
            return _mapper.Map<WordDto>(randomWord);
        }

        [HttpGet("permutations")]
        public WordPermutationsDto GetWordPermutations([FromQuery] WordPermutationsFilterDto filterDto)
        {
            var filter = _mapper.Map<WordPermutationsFilter>(filterDto);
            var permutations = _wordService.GetPermutations(filter);
            return _mapper.Map<WordPermutationsDto>(permutations);
        }
    }
}
