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

    public virtual AwardPeriod? AwardPeriod { get; set; }

    public virtual AwardCategory? Category { get; set; }
}
