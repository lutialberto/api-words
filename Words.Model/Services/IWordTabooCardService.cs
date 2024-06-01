using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Model.Entities;

namespace Words.Model.Services
{
    public interface IWordTabooCardService
    {
        public WordTabooCard GetWordTabooCard(List<int> wordIdsToExclude);
    }
}
