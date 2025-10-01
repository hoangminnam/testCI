using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class AwardCategory
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Order { get; set; }

    public Guid? ParentCategory { get; set; }

    public virtual ICollection<Award> Awards { get; set; } = new List<Award>();

    public virtual ICollection<AwardCategory> InverseParentCategoryNavigation { get; set; } = new List<AwardCategory>();

    public virtual ICollection<Nominee> Nominees { get; set; } = new List<Nominee>();

    public virtual AwardCategory? ParentCategoryNavigation { get; set; }

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    public virtual ICollection<EvaluationCriterion> EvaluationCriteria { get; set; } = new List<EvaluationCriterion>();

}
