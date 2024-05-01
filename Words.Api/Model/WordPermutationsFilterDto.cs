namespace Words.Api.Model
{
    public class WordPermutationsFilterDto
    {
        public string? Substring { get; set; }
        public int? Length { get; set; }
        public IEnumerable<string>? Letters { get; set; }
    }
}
