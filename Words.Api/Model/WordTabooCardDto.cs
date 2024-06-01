namespace Words.Api.Model
{
    public class WordTabooCardDto
    {
        public int Id { get; set; }
        public string WordToGuess { get; set; }
        public IEnumerable<string> UnmentionableWords { get; set; }
    }
}
