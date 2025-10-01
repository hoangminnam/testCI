using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class EvaluationCriterion
{
    public Guid Id { get; set; }
    public Guid AwardCategoryId { get; set; }


    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? MaxScore { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    public virtual AwardCategory AwardCategory { get; set; } = null!;

}
