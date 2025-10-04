using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Nominee
{
    public Guid Id { get; set; }

    public Guid? SubmittedById { get; set; }

    public Guid? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Summary { get; set; }

    public string? Title { get; set; }

    public string? ImageUrl { get; set; }

    public string? VideoUrl { get; set; }

    public string? Content { get; set; }

    public string? RelatedInfo { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual AwardCategory? Category { get; set; }

    public virtual ICollection<CommentNominee>? CommentNominees { get; set; } = new List<CommentNominee>();

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<NominateActionLog> NominateActionLogs { get; set; } = new List<NominateActionLog>();

    public virtual User? SubmittedBy { get; set; }

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
