using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Entities
{
    public class WordPermutations
    {
        public IEnumerable<string> Permutations { get; set; } = [];
        public IEnumerable<char> Letters { get; set; } = [];
    }
}
