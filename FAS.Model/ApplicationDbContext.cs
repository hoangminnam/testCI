using System;
using System.Collections.Generic;
using FAS.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace FAS.Model;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FAS_Database;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

    public virtual DbSet<AdminActionLog> AdminActionLogs { get; set; }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<AwardCategory> AwardCategories { get; set; }

    public virtual DbSet<AwardPeriod> AwardPeriods { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<CommentNominee> CommentNominees { get; set; }

    public virtual DbSet<CouncilMember> CouncilMembers { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<EvaluationCriterion> EvaluationCriteria { get; set; }

    public virtual DbSet<NominateActionLog> NominateActionLogs { get; set; }

    public virtual DbSet<Nominee> Nominees { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminAct__3213E83F7A9CAFA1");

            entity.ToTable("AdminActionLog");

            entity.HasIndex(e => e.Id, "UQ__AdminAct__3213E83E42988AEA").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActionType).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AdminActionLog)
                .HasForeignKey<AdminActionLog>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminActionL__id__60A75C0F");
        });

        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Award__3213E83F3BDEEB17");

            entity.ToTable("Award");

            entity.HasIndex(e => e.Id, "UQ__Award__3213E83ED73AD8EE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Awards)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Award__CategoryI__5DCAEF64");
        });

        modelBuilder.Entity<AwardCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AwardCat__3213E83FD3F90307");

            entity.ToTable("AwardCategory");

            entity.HasIndex(e => e.Id, "UQ__AwardCat__3213E83EAAAAD18F").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.ParentCategoryNavigation).WithMany(p => p.InverseParentCategoryNavigation)
                .HasForeignKey(d => d.ParentCategory)
                .HasConstraintName("FK__AwardCate__Paren__6383C8BA");
        });

        modelBuilder.Entity<AwardPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AwardPer__3213E83F270BACB7");

            entity.ToTable("AwardPeriod");

            entity.HasIndex(e => e.Id, "UQ__AwardPer__3213E83E585E425B").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Award)
                .WithMany(p => p.AwardPeriods)
                .HasForeignKey(d => d.AwardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AwardPeriod__AwardId__5EBF139D");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blog__3213E83F141A6B93");

            entity.ToTable("Blog");

            entity.HasIndex(e => e.Id, "UQ__Blog__3213E83E7D05D484").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Blog__CreatedBy__6A30C649");
        });

        modelBuilder.Entity<CommentNominee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CommentN__3213E83F5FD7C052");

            entity.ToTable("CommentNominee");

            entity.HasIndex(e => e.Id, "UQ__CommentN__3213E83ECA8964CD").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(255);

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CommentNominees)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__CommentNo__Creat__6C190EBB");

            entity.HasOne(d => d.Nominee)
                .WithMany(p => p.CommentNominees)
                .HasForeignKey(d => d.NomineeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CommentNo__NomineeId__6B24EA82");
        });

        modelBuilder.Entity<CouncilMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouncilM__3213E83FD0498D1E");

            entity.ToTable("CouncilMember");

            entity.HasIndex(e => e.Id, "UQ__CouncilM__3213E83E0EBE96D0").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CouncilMember)
                .HasForeignKey<CouncilMember>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouncilMembe__id__66603565");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evaluati__3213E83F965D3AFC");

            entity.ToTable("Evaluation");

            entity.HasIndex(e => e.Id, "UQ__Evaluati__3213E83E49B00C01").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CouncilMember).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.CouncilMemberId)
                .HasConstraintName("FK__Evaluatio__Counc__6754599E");

            entity.HasOne(d => d.Criteria).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.CriteriaId)
                .HasConstraintName("FK__Evaluatio__Crite__68487DD7");

            entity.HasOne(d => d.Nominee).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.NomineeId)
                .HasConstraintName("FK__Evaluatio__Nomin__693CA210");
        });

        modelBuilder.Entity<EvaluationCriterion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evaluati__3213E83FB305C922");

            entity.HasIndex(e => e.Id, "UQ__Evaluati__3213E83EF651AA92").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.AwardCategoryId).HasColumnName("award_category_id");
            entity.HasOne(e => e.AwardCategory)
          .WithMany(c => c.EvaluationCriteria)
          .HasForeignKey(e => e.AwardCategoryId)
          .OnDelete(DeleteBehavior.Cascade)  
          .HasConstraintName("FK_EvaluationCriterion_AwardCategory");
        });

        modelBuilder.Entity<NominateActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nominate__3213E83F057877EB");

            entity.ToTable("NominateActionLog");

            entity.HasIndex(e => e.Id, "UQ__Nominate__3213E83E5828620A").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActionType).HasMaxLength(255);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Nominee).WithMany(p => p.NominateActionLogs)
                .HasForeignKey(d => d.NomineeId)
                .HasConstraintName("FK__NominateA__Nomin__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.NominateActionLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__NominateA__UserI__6FE99F9F");
        });

        modelBuilder.Entity<Nominee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nominee__3213E83F2715F9C0");

            entity.ToTable("Nominee");

            entity.HasIndex(e => e.Id, "UQ__Nominee__3213E83E538B9919").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RelatedInfo).HasMaxLength(255);
            entity.Property(e => e.Summary).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Nominees)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Nominee__Categor__656C112C");

            entity.HasOne(d => d.SubmittedBy)
                .WithMany(p => p.Nominees)
                .HasForeignKey(d => d.SubmittedById)
                .HasConstraintName("FK__Nominee__Submitt__5FB337D6");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F6F4D47AF");

            entity.ToTable("Notification");

            entity.HasIndex(e => e.Id, "UQ__Notifica__3213E83E427741B6").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Notificat__Creat__6D0D32F4");

            entity.HasOne(d => d.TargetUserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TargetUser)
                .HasConstraintName("FK__Notificat__Targe__6E01572D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F4AB77DCF");

            entity.ToTable("User");

            entity.HasIndex(e => e.Id, "UQ__User__3213E83E347A65C7").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FapId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
        });

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vote__3213E83FD93E9124");

            entity.ToTable("Vote");

            entity.HasIndex(e => e.Id, "UQ__Vote__3213E83E1BC43205").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Votes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Vote__CategoryId__6477ECF3");

            entity.HasOne(d => d.Nominee).WithMany(p => p.Votes)
                .HasForeignKey(d => d.NomineeId)
                .HasConstraintName("FK__Vote__NomineeId__628FA481");

            entity.HasOne(d => d.User).WithMany(p => p.Votes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vote__UserId__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
