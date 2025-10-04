using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class CommentNominee
{
    public Guid Id { get; set; }

    public Guid? NomineeId { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? Comment { get; set; }

    public virtual AdminActionLog? CreatedByNavigation { get; set; }

    public virtual Nominee? Nominee { get; set; } = null!;
}
