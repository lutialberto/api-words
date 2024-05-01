using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Filters
{
    public class WordPermutationsFilter
    {
        public string? Substring { get; set; }
        public int? Length { get; set; }
        public IEnumerable<string>? Letters { get; set; }
    }
}
