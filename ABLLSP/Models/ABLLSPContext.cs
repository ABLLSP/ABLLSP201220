using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ABLLSP.Models
{
    public partial class ABLLSPContext : DbContext
    {
        public ABLLSPContext()
        {
        }

        public ABLLSPContext(DbContextOptions<ABLLSPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbllspdesignationMaster> AbllspdesignationMasters { get; set; }
        public virtual DbSet<AbllspmemberMaster> AbllspmemberMasters { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventsMedium> EventsMedia { get; set; }
        public virtual DbSet<FamilyHeadInfo> FamilyHeadInfos { get; set; }
        public virtual DbSet<FamilyMemberInfo> FamilyMemberInfos { get; set; }
        public virtual DbSet<MatriMonialProfile> MatriMonialProfiles { get; set; }
        public virtual DbSet<MatriMonialProfileAttachment> MatriMonialProfileAttachments { get; set; }
        public virtual DbSet<PrantDesignationMaster> PrantDesignationMasters { get; set; }
        public virtual DbSet<PrantMaster> PrantMasters { get; set; }
        public virtual DbSet<PrantMemberMaster> PrantMemberMasters { get; set; }
        public virtual DbSet<ShaharDesignationMaster> ShaharDesignationMasters { get; set; }
        public virtual DbSet<ShaharMaster> ShaharMasters { get; set; }
        public virtual DbSet<ShaharMemberMaster> ShaharMemberMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//<<<<<<< HEAD
               //optionsBuilder.UseSqlServer("Server=13.233.244.159;Trusted_Connection=false;Database=ABLLSP;User ID=abllsp201220;Password=AbLLsP@201220");
                //optionsBuilder.UseSqlServer("Server=52.172.165.131,54029;Trusted_Connection=false;Database=ABLLSP;User ID=abllsp201220;Password=AbLLsP@201220");
                //=======
                //optionsBuilder.UseSqlServer("Server=13.233.244.159;Trusted_Connection=false;Database=ABLLSP;User ID=abllsp201220;Password=AbLLsP@201220");
                //>>>>>>> 62d2d3ae8e3be14f2d1c2d92f78626bd3ed7478c
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AbllspdesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.ToTable("ABLLSPDesignationMaster");

                entity.Property(e => e.DesignationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AbllspmemberMaster>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_ABLLSPMember");

                entity.ToTable("ABLLSPMemberMaster");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMailID");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(e => e.AbllspdesignationMaster);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventsMedium>(entity =>
            {
                entity.HasKey(e => e.MediaId);

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.MediaUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MediaURL");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<FamilyHeadInfo>(entity =>
            {
                entity.HasKey(e => e.FamilyId);

                entity.ToTable("FamilyHeadInfo");

                entity.Property(e => e.FamilyId).HasColumnName("FamilyID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMailID");

                entity.Property(e => e.FamilyHeadName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShaharId).HasColumnName("ShaharID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(e => e.ShaharMaster);
                entity.HasMany(e => e.FamilyMemberInfos);

            });

            modelBuilder.Entity<FamilyMemberInfo>(entity =>
            {
                entity.HasKey(e => e.FamilyMemberId);

                entity.ToTable("FamilyMemberInfo");

                entity.Property(e => e.FamilyMemberId).HasColumnName("FamilyMemberID");

                entity.Property(e => e.Education)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyId).HasColumnName("FamilyID");

                entity.Property(e => e.FamilyMemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Relation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.Property(e => e.FamilyHeadInfo).HasColumnName("FamilyHeadInfo");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(e => e.FamilyHeadInfo);
            });

            modelBuilder.Entity<MatriMonialProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirthTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Education)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMailID");

                entity.Property(e => e.FamilyId).HasColumnName("FamilyID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hobbies)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OtherInfo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SiblingInfo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MatriMonialProfileAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<PrantDesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.ToTable("PrantDesignationMaster");

                entity.Property(e => e.DesignationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasMany(e => e.PrantMembers);

            });

            modelBuilder.Entity<PrantMaster>(entity =>
            {
                entity.HasKey(e => e.PrantId);

                entity.ToTable("PrantMaster");

                entity.Property(e => e.PrantId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PrantID");

                entity.Property(e => e.PrantInfo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrantName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasMany(e => e.PrantMembers);
                entity.HasMany(e => e.ShaharMasters);
            });

            modelBuilder.Entity<PrantMemberMaster>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("PrantMemberMaster");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMailID");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrantId).HasColumnName("PrantID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(e => e.PrantDesignationMaster);
                entity.HasOne(e => e.PrantMaster);
            });

            modelBuilder.Entity<ShaharDesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.ToTable("ShaharDesignationMaster");

                entity.Property(e => e.DesignationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShaharMaster>(entity =>
            {
                entity.HasKey(e => e.ShaharId);

                entity.ToTable("ShaharMaster");

                entity.Property(e => e.ShaharId).HasColumnName("ShaharID");

                entity.Property(e => e.PrantId).HasColumnName("PrantID");

                entity.Property(e => e.ShaharInfo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShaharName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

               // object p = entity.HasMany(e => e.ShaharMaster);
                entity.HasMany(e => e.FamilyHeadInfos);
                entity.HasOne(e => e.PrantMaster);
            });

            modelBuilder.Entity<ShaharMemberMaster>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("ShaharMemberMaster");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMailID");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShaharId).HasColumnName("ShaharID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(e => e.ShaharDesignationMaster);
                entity.HasOne(e => e.ShaharMaster);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
