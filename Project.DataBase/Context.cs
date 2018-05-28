using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Project.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Project.DataBase
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Concretejournal> Concretejournals { get; set; }
        public DbSet<ConcretejournalComment> ConcretejournalComments { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Journalarticle> Journalarticles { get; set; }
        public DbSet<JournalarticleSubcategory> JournalarticleSubcategories { get; set; }
        public DbSet<JournalCategory> JournalCategories { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonJournalarticle> PersonJournalarticles { get; set; }
        public DbSet<Personrole> Personroles { get; set; }
        public DbSet<Publishingcompany> Publishingcompanies { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<SubcategoryCategory> SubcategoryCategories { get; set; }
        public DbSet<Word> Words { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Project_Journal_Test;Trusted_Connection=True;");
        //}

        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .HasOne(p => p.Personrole)
            .WithMany(pr => pr.Persons)
            .HasForeignKey(p => p.PersonroleID);

            modelBuilder.Entity<PersonJournalarticle>()
            .HasKey(pja => new { pja.PersonID, pja.JournalarticleID });

            modelBuilder.Entity<PersonJournalarticle>()
            .HasOne(pja => pja.Person)
            .WithMany(p => p.PersonJournalarticles)
            .HasForeignKey(pja => pja.PersonID);

            modelBuilder.Entity<PersonJournalarticle>()
            .HasOne(pja => pja.Journalarticle)
            .WithMany(ja => ja.PersonJournalarticles)
            .HasForeignKey(pja => pja.JournalarticleID);

            modelBuilder.Entity<Journalarticle>()
            .HasOne(ja => ja.ConcreteJournal)
            .WithMany(cj => cj.Journalarticles)
            .HasForeignKey(ja => ja.ConcreteJournalID);

            modelBuilder.Entity<Concretejournal>()
            .HasOne(cj => cj.Journal)
            .WithMany(j => j.Concretejournals)
            .HasForeignKey(cj => cj.JournalID);

            modelBuilder.Entity<ConcretejournalComment>()
            .HasKey(cjc => new { cjc.ConcretejournalID, cjc.CommentID });

            modelBuilder.Entity<ConcretejournalComment>()
            .HasOne(cjc => cjc.Concretejournal)
            .WithMany(cj => cj.ConcretejournalComments)
            .HasForeignKey(cjc => cjc.ConcretejournalID)
            .HasPrincipalKey(cjc => cjc.ConcretejournalID);

            modelBuilder.Entity<ConcretejournalComment>()
            .HasOne(cjc => cjc.Comment)
            .WithMany(c => c.ConcretejournalComments)
            .HasForeignKey(cjc => cjc.CommentID)
            .HasPrincipalKey(cjc => cjc.CommentID);

            modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<JournalCategory>()
            .HasKey(jc => new { jc.JournalID, jc.CategoryID });

            modelBuilder.Entity<JournalCategory>()
            .HasOne(jc => jc.Journal)
            .WithMany(j => j.JournalCategories)
            .HasForeignKey(jc => jc.JournalID);

            modelBuilder.Entity<JournalCategory>()
            .HasOne(jc => jc.Category)
            .WithMany(c => c.JournalCategories)
            .HasForeignKey(jc => jc.CategoryID);

            modelBuilder.Entity<Journal>()
            .HasOne(j => j.PublishingCompany)
            .WithMany(p => p.Journals)
            .HasForeignKey(j => j.PublishingCompanyID);

            modelBuilder.Entity<SubcategoryCategory>()
            .HasKey(sc => new { sc.SubcategoryID, sc.CategoryID });

            modelBuilder.Entity<SubcategoryCategory>()
            .HasOne(sc => sc.Category)
            .WithMany(c => c.SubcategoryCategories)
            .HasForeignKey(sc => sc.CategoryID);

            modelBuilder.Entity<SubcategoryCategory>()
            .HasOne(scc => scc.Subcategory)
            .WithMany(sc => sc.SubcategoryCategories)
            .HasForeignKey(scc => scc.SubcategoryID);

            modelBuilder.Entity<JournalarticleSubcategory>()
            .HasKey(jas => new { jas.JournalarticleID, jas.SubcategoryID });

            modelBuilder.Entity<JournalarticleSubcategory>()
            .HasOne(jas => jas.Journalarticle)
            .WithMany(ja => ja.JournalarticleSubcategories)
            .HasForeignKey(jas => jas.JournalarticleID);

            modelBuilder.Entity<JournalarticleSubcategory>()
            .HasOne(jas => jas.Subcategory)
            .WithMany(sc => sc.JournalarticleSubcategoies)
            .HasForeignKey(jas => jas.SubcategoryID);

            modelBuilder.Entity<KeyWord>()
            .HasKey(kw => new { kw.WordID, kw.JournalarticleID });

            modelBuilder.Entity<KeyWord>()
            .HasOne(kw => kw.Word)
            .WithMany(w => w.KeyWords)
            .HasForeignKey(kw => kw.WordID);

            modelBuilder.Entity<KeyWord>()
            .HasOne(kw => kw.Journalarticle)
            .WithMany(ja => ja.Keywords)
            .HasForeignKey(kw => kw.JournalarticleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
