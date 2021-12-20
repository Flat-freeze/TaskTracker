using AutoFilter;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models.Filtrers
{
    public class TitleFilter
    {
        [FilterProperty(IgnoreCase = true,
                          TargetPropertyName = "Title",
                          StringFilter = StringFilterCondition.Contains
                        )]
        public string? Title { get; set; }
        [NotAutoFiltered]
        public string? OrderBy { get; set; }
        [NotAutoFiltered]
        public bool Desk { get; set; }
    }
}
