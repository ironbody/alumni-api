﻿// <auto-generated />
using System;
using AlumniAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlumniAPI.Migrations
{
    [DbContext(typeof(AlumniDbContext))]
    partial class AlumniDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlumniAPI.Models.DirectMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("DirectMessage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Hello Mr.Moomin how are you?",
                            RecipientId = 3,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Body = "Hey, im a bit depressed. I might need a kong strong...",
                            RecipientId = 1,
                            SenderId = 3,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 57, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Body = "lol",
                            RecipientId = 3,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 5, 50, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Body = "blablabla",
                            RecipientId = 2,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Body = "blablabla",
                            RecipientId = 3,
                            SenderId = 2,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.EventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("EventInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new DateTime(2023, 9, 10, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "My place",
                            PostId = 2,
                            Start = new DateTime(2023, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Group");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Group for people who lowes kayaking.",
                            Name = "Kayakers"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Group for people who want to sing kareoke.",
                            Name = "Kareoke Nights"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Group for people who LOVE spongebob",
                            Name = "Spongebob Fanatics"
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("GroupId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "So we're having a skibidi event. If anyone have any good ideas, please write them down below.",
                            CreatedDateTime = new DateTime(2023, 9, 4, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            GroupId = 1,
                            Title = "Ideas for the skibidi event"
                        },
                        new
                        {
                            Id = 2,
                            Body = "Kräftskiva at my place, BYOB",
                            CreatedDateTime = new DateTime(2023, 9, 3, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 2,
                            GroupId = 2,
                            Title = "Kräftskiva"
                        },
                        new
                        {
                            Id = 3,
                            Body = "Wow this post is edited. Isn't that crazy?",
                            CreatedDateTime = new DateTime(2023, 9, 4, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 3,
                            EditedDateTime = new DateTime(2023, 9, 4, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 3,
                            Title = "I love editing posts"
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("ReplyToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ReplyToId");

                    b.ToTable("Reply");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "I think we should have drinks and scooby snacks",
                            CreatorId = 2,
                            ReplyToId = 1
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Test");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Oscar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Simon"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Erik"
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarURL")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Bio")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FunFact")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarURL = "https://temashopse.b-cdn.net/media/catalog/product/cache/cat_resized/1200/0/s/h/shrek_r_maskeraddrakt_maskeraddrakter_maskeradklader_for_man.jpg",
                            Bio = "Shrek/Kong lover",
                            FunFact = "Loves Shrek and Kong",
                            Name = "Oscar"
                        },
                        new
                        {
                            Id = 2,
                            AvatarURL = "https://preview.redd.it/ufc-fight-night-shrek-vs-adam-sandler-v0-d3r78jgnhmv91.jpg?width=512&format=pjpg&auto=webp&s=2f93c0115d58a24e638a69f0a21fc571da99ac55",
                            Bio = "Hello I'm Simon and I love HAVREFLARN med choklad",
                            FunFact = "Cookie lover XD",
                            Name = "Simon"
                        },
                        new
                        {
                            Id = 3,
                            AvatarURL = "https://pbs.twimg.com/profile_images/1342617687663521793/4lVjmcIk_400x400.jpg",
                            Bio = "Erik aka MuminLover1337",
                            FunFact = "I LOVE MUUUUMIN!",
                            Name = "Erik"
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.UserGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroup");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            UserId = 1
                        },
                        new
                        {
                            GroupId = 2,
                            UserId = 2
                        },
                        new
                        {
                            GroupId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("AlumniAPI.Models.DirectMessage", b =>
                {
                    b.HasOne("AlumniAPI.Models.User", "Recipient")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlumniAPI.Models.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("AlumniAPI.Models.EventInfo", b =>
                {
                    b.HasOne("AlumniAPI.Models.Post", "Post")
                        .WithOne("EventInfo")
                        .HasForeignKey("AlumniAPI.Models.EventInfo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("AlumniAPI.Models.Post", b =>
                {
                    b.HasOne("AlumniAPI.Models.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniAPI.Models.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("AlumniAPI.Models.Reply", b =>
                {
                    b.HasOne("AlumniAPI.Models.User", "Creator")
                        .WithMany("Replies")
                        .HasForeignKey("CreatorId");

                    b.HasOne("AlumniAPI.Models.Post", "ReplyTo")
                        .WithMany("Replies")
                        .HasForeignKey("ReplyToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("ReplyTo");
                });

            modelBuilder.Entity("AlumniAPI.Models.UserGroup", b =>
                {
                    b.HasOne("AlumniAPI.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlumniAPI.Models.Group", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("AlumniAPI.Models.Post", b =>
                {
                    b.Navigation("EventInfo");

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("AlumniAPI.Models.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("Replies");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
