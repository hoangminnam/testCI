using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Model.DTOs
{

    public class AwardCategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Order { get; set; }
        public Guid? ParentCategory { get; set; }
    }

    public class AwardCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Order { get; set; }
        public Guid? ParentCategory { get; set; }
    }

}
