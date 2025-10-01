  using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Evaluation
{
    public Guid Id { get; set; }

    public Guid? CouncilMemberId { get; set; }

    public Guid? NomineeId { get; set; }

    public Guid? CriteriaId { get; set; }

    public int? Score { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CouncilMember? CouncilMember { get; set; }

    public virtual EvaluationCriterion? Criteria { get; set; }

    public virtual Nominee? Nominee { get; set; }
}
