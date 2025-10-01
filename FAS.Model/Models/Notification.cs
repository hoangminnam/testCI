using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Notification
{
    public Guid Id { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? TargetUser { get; set; }

    public DateTime? Time { get; set; }

    public string? Content { get; set; }

    public virtual AdminActionLog? CreatedByNavigation { get; set; }

    public virtual User? TargetUserNavigation { get; set; }
}
