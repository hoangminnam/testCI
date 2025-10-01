using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Model.DTOs
{
    public class EvaluationCriterionDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaxScore { get; set; }
        public Guid AwardCategoryId { get; set; }
        public string? AwardCategoryName { get; set; }
    }

    public class CreateEvaluationCriterionDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaxScore { get; set; }
        public Guid AwardCategoryId { get; set; }
    }

    public class UpdateEvaluationCriterionDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaxScore { get; set; }
        public Guid AwardCategoryId { get; set; }
    }

}
