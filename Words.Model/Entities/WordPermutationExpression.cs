using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Entities
{
    public class WordPermutationExpression
    {
        [Key]
        public int WordId { get; set; }
        public string WordSimpleValue { get; set; }
        public string LettersSorted { get; set; }
        public string LettersSet { get; set; }
        public long LettersSetOcurrences { get; set; }
        public string PermutationRegExp { get; set; }
    }
}
