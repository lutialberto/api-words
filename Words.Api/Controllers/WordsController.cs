using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Words.Api.Model;
using Words.Model.Filters;
using Words.Model.Services;

namespace Words.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        private readonly ILogger<WordsController> _logger;
        private readonly IWordService _wordService;
        private IMapper _mapper;

        public WordsController(
            ILogger<WordsController> logger,
            IWordService wordService,
            IMapper mapper
        )
        {
            _logger = logger;
            _wordService = wordService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WordDto> Get([FromQuery] WordFilterDto filterDto)
        {
            var filter = _mapper.Map<WordFilter>(filterDto);
            var words = _wordService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<WordDto>>(words);
        }
    }
}
