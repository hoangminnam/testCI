using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Award
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Year { get; set; }

    public int? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CategoryId { get; set; }

    public int? IsActive { get; set; }

    public virtual ICollection<AwardPeriod>? AwardPeriods { get; set; } = new List<AwardPeriod>();

    public virtual AwardCategory? Category { get; set; }
}
