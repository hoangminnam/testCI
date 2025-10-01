using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class AdminActionLog
{
    public Guid Id { get; set; }

    public string? ActionType { get; set; }

    public Guid? PerformedById { get; set; }

    public Guid? TargetId { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<CommentNominee> CommentNominees { get; set; } = new List<CommentNominee>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
