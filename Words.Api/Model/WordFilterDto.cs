namespace Words.Api.Model
{
    public class WordFilterDto : PaginationFilterDto
    {
        public int? Length { get; set; }
    }
}
