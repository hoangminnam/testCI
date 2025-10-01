using System;
using System.Collections.Generic;

namespace FAS.Model.Models;

public partial class Vote
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? NomineeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual AwardCategory? Category { get; set; }

    public virtual Nominee? Nominee { get; set; }

    public virtual User? User { get; set; }
}
