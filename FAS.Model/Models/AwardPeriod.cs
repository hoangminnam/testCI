using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class AwardPeriod
{
    public Guid Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? IsActive { get; set; }

    public virtual Award IdNavigation { get; set; } = null!;
}
