using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class CodeExchangeContext : DbContext
    {
        public CodeExchangeContext()
        {
        }

        public CodeExchangeContext(DbContextOptions<CodeExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerComment> AnswerComments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionComment> QuestionComments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeExchange;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Answer__56A40CF630093F81");

                entity.ToTable("Answer");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.Property(e => e.QId).HasColumnName("q-id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.Answer)
                    .HasForeignKey<Answer>(d => d.PId)
                    .HasConstraintName("FK__Answer__p-id__37A5467C");

                entity.HasOne(d => d.QIdNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QId)
                    .HasConstraintName("FK__Answer__q-id__38996AB5");
            });

            modelBuilder.Entity<AnswerComment>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__AnswerCo__56A40CF659F9C356");

                entity.ToTable("AnswerComment");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.Property(e => e.AId).HasColumnName("a-id");

                entity.HasOne(d => d.AIdNavigation)
                    .WithMany(p => p.AnswerComments)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__AnswerComm__a-id__4316F928");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.AnswerComment)
                    .HasForeignKey<AnswerComment>(d => d.PId)
                    .HasConstraintName("FK__AnswerComm__p-id__4222D4EF");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Comment__56A40CF60683A90D");

                entity.ToTable("Comment");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.Comment)
                    .HasForeignKey<Comment>(d => d.PId)
                    .HasConstraintName("FK__Comment__p-id__3B75D760");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Post__56A40CF6E8A4F249");

                entity.ToTable("Post");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.Property(e => e.Body)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Votes).HasColumnName("votes");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Post__username__31EC6D26");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Question__56A40CF692F44DF9");

                entity.ToTable("Question");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.Property(e => e.Header)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("header");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.Question)
                    .HasForeignKey<Question>(d => d.PId)
                    .HasConstraintName("FK__Question__p-id__34C8D9D1");
            });

            modelBuilder.Entity<QuestionComment>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Question__56A40CF63A25F849");

                entity.ToTable("QuestionComment");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p-id");

                entity.Property(e => e.QId).HasColumnName("q-id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.QuestionComment)
                    .HasForeignKey<QuestionComment>(d => d.PId)
                    .HasConstraintName("FK__QuestionCo__p-id__3E52440B");

                entity.HasOne(d => d.QIdNavigation)
                    .WithMany(p => p.QuestionComments)
                    .HasForeignKey(d => d.QId)
                    .HasConstraintName("FK__QuestionCo__q-id__3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__F3DBC573A8A342F4");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
