using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public byte? Role { get; set; }

    public string? FapId { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? VoteStatus { get; set; }

    public virtual AdminActionLog? AdminActionLog { get; set; }

    public virtual CouncilMember? CouncilMember { get; set; }

    public virtual ICollection<NominateActionLog> NominateActionLogs { get; set; } = new List<NominateActionLog>();

    public virtual ICollection<Nominee> Nominees { get; set; } = new List<Nominee>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
