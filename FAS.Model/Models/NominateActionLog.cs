using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class NominateActionLog
{
    public Guid Id { get; set; }

    public Guid? NomineeId { get; set; }

    public Guid? UserId { get; set; }

    public string? ActionType { get; set; }

    public DateTime? Time { get; set; }

    public virtual Nominee? Nominee { get; set; }

    public virtual User? User { get; set; }
}
