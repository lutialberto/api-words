﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Model.Filters
{
    public class PaginationFilter
    {
        public int PageSize { get; set; } = 1;
        public int PageNumber { get; set; } = 0;
    }
}
