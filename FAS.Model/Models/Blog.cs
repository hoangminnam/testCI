using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Blog
{
    public Guid Id { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual AdminActionLog? CreatedByNavigation { get; set; }
}
