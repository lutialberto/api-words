namespace Words.Model.Filters
{
    public class WordFilter
    {
        public int? Length { get; set; }
        public string? Value { get; set; }
        public string? SimpleValue { get; set; }
        public string? Substring { get; set; }
        public IEnumerable<char>? Letters { get; set; }
    }
}
