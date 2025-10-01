using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class CouncilMember
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Position { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual User IdNavigation { get; set; } = null!;
}
