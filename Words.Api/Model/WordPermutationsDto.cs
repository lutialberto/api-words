namespace Words.Api.Model
{
    public class WordPermutationsDto
    {
        public IEnumerable<string> Permutations { get; set; }
        public IEnumerable<char> Letters { get; set; }
    }
}
