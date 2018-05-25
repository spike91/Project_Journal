﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Project.DataBase;
using System;

namespace Project.DataBase.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Project.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Project.Entities.Comment", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("CommentID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Project.Entities.Concretejournal", b =>
                {
                    b.Property<int>("ConcretejournalID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("JournalID");

                    b.Property<string>("Number");

                    b.HasKey("ConcretejournalID");

                    b.HasIndex("JournalID");

                    b.ToTable("Concretejournals");
                });

            modelBuilder.Entity("Project.Entities.ConcretejournalComment", b =>
                {
                    b.Property<int>("ConcretejournalID");

                    b.Property<int>("CommentID");

                    b.HasKey("ConcretejournalID", "CommentID");

                    b.HasIndex("CommentID");

                    b.ToTable("ConcretejournalComments");
                });

            modelBuilder.Entity("Project.Entities.Journal", b =>
                {
                    b.Property<int>("JournalID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language");

                    b.Property<int>("Pages");

                    b.Property<int>("PublishingCompanyID");

                    b.Property<string>("Site");

                    b.Property<string>("Title");

                    b.HasKey("JournalID");

                    b.HasIndex("PublishingCompanyID");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("Project.Entities.Journalarticle", b =>
                {
                    b.Property<int>("JournalArticleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConcreteJournalID");

                    b.Property<string>("Description");

                    b.Property<int>("Page");

                    b.Property<string>("Title");

                    b.HasKey("JournalArticleID");

                    b.HasIndex("ConcreteJournalID");

                    b.ToTable("Journalarticles");
                });

            modelBuilder.Entity("Project.Entities.JournalarticleSubcategory", b =>
                {
                    b.Property<int>("JournalarticleID");

                    b.Property<int>("SubcategoryID");

                    b.HasKey("JournalarticleID", "SubcategoryID");

                    b.HasIndex("SubcategoryID");

                    b.ToTable("JournalarticleSubcategories");
                });

            modelBuilder.Entity("Project.Entities.JournalCategory", b =>
                {
                    b.Property<int>("JournalID");

                    b.Property<int>("CategoryID");

                    b.HasKey("JournalID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("JournalCategories");
                });

            modelBuilder.Entity("Project.Entities.KeyWord", b =>
                {
                    b.Property<int>("WordID");

                    b.Property<int>("JournalarticleID");

                    b.HasKey("WordID", "JournalarticleID");

                    b.HasIndex("JournalarticleID");

                    b.ToTable("KeyWords");
                });

            modelBuilder.Entity("Project.Entities.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PersonroleID");

                    b.HasKey("PersonID");

                    b.HasIndex("PersonroleID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Project.Entities.PersonJournalarticle", b =>
                {
                    b.Property<int>("PersonID");

                    b.Property<int>("JournalarticleID");

                    b.HasKey("PersonID", "JournalarticleID");

                    b.HasIndex("JournalarticleID");

                    b.ToTable("PersonJournalarticles");
                });

            modelBuilder.Entity("Project.Entities.Personrole", b =>
                {
                    b.Property<int>("PersonroleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("PersonroleID");

                    b.ToTable("Personroles");
                });

            modelBuilder.Entity("Project.Entities.Publishingcompany", b =>
                {
                    b.Property<int>("PublishingcompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Site");

                    b.HasKey("PublishingcompanyID");

                    b.ToTable("Publishingcompanies");
                });

            modelBuilder.Entity("Project.Entities.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SubcategoryID");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("Project.Entities.SubcategoryCategory", b =>
                {
                    b.Property<int>("SubcategoryID");

                    b.Property<int>("CategoryID");

                    b.HasKey("SubcategoryID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubcategoryCategories");
                });

            modelBuilder.Entity("Project.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Project.Entities.Word", b =>
                {
                    b.Property<int>("WordID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("WordID");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Project.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.Comment", b =>
                {
                    b.HasOne("Project.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.Concretejournal", b =>
                {
                    b.HasOne("Project.Entities.Journal", "Journal")
                        .WithMany("Concretejournals")
                        .HasForeignKey("JournalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.ConcretejournalComment", b =>
                {
                    b.HasOne("Project.Entities.Comment", "Comment")
                        .WithMany("ConcretejournalComments")
                        .HasForeignKey("CommentID")
                        .HasPrincipalKey("CommentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Concretejournal", "Concretejournal")
                        .WithMany("ConcretejournalComments")
                        .HasForeignKey("ConcretejournalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.Journal", b =>
                {
                    b.HasOne("Project.Entities.Publishingcompany", "PublishingCompany")
                        .WithMany("Journals")
                        .HasForeignKey("PublishingCompanyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.Journalarticle", b =>
                {
                    b.HasOne("Project.Entities.Concretejournal", "ConcreteJournal")
                        .WithMany("Journalarticles")
                        .HasForeignKey("ConcreteJournalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.JournalarticleSubcategory", b =>
                {
                    b.HasOne("Project.Entities.Journalarticle", "Journalarticle")
                        .WithMany("JournalarticleSubcategories")
                        .HasForeignKey("JournalarticleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Subcategory", "Subcategory")
                        .WithMany("JournalarticleSubcategoies")
                        .HasForeignKey("SubcategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.JournalCategory", b =>
                {
                    b.HasOne("Project.Entities.Category", "Category")
                        .WithMany("JournalCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Journal", "Journal")
                        .WithMany("JournalCategories")
                        .HasForeignKey("JournalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.KeyWord", b =>
                {
                    b.HasOne("Project.Entities.Journalarticle", "Journalarticle")
                        .WithMany("Keywords")
                        .HasForeignKey("JournalarticleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Word", "Word")
                        .WithMany("KeyWords")
                        .HasForeignKey("WordID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.Person", b =>
                {
                    b.HasOne("Project.Entities.Personrole", "Personrole")
                        .WithMany("Persons")
                        .HasForeignKey("PersonroleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.PersonJournalarticle", b =>
                {
                    b.HasOne("Project.Entities.Journalarticle", "Journalarticle")
                        .WithMany("PersonJournalarticles")
                        .HasForeignKey("JournalarticleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Person", "Person")
                        .WithMany("PersonJournalarticles")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Entities.SubcategoryCategory", b =>
                {
                    b.HasOne("Project.Entities.Category", "Category")
                        .WithMany("SubcategoryCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Entities.Subcategory", "Subcategory")
                        .WithMany("SubcategoryCategories")
                        .HasForeignKey("SubcategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
