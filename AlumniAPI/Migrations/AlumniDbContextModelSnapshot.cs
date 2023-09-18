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
                            Body = "Hello Erik, how did you eat soo many pieces in one sitting???",
                            RecipientId = 3,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Body = "It was easy, I just did it.",
                            RecipientId = 1,
                            SenderId = 3,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 57, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Body = "Wow, very cool!",
                            RecipientId = 3,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 5, 50, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Body = "Hello Simon, how are you?",
                            RecipientId = 2,
                            SenderId = 1,
                            SentTime = new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Body = "Hey Oscar! Good, I just ate 10 havreflarn!",
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

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Image")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Group");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = 1,
                            Description = "Group for people who lowes kayaking.",
                            Name = "Kayakers",
                            Private = false
                        },
                        new
                        {
                            Id = 2,
                            CreatorId = 2,
                            Description = "Group for people who want to sing karaoke.",
                            Name = "Karaoke Nights",
                            Private = false
                        },
                        new
                        {
                            Id = 3,
                            CreatorId = 3,
                            Description = "Group for people who LOVE spongebob",
                            Name = "Spongebob Fanatics",
                            Private = false
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
                            Body = "So we're having a event. If anyone have any good ideas, please write them down below.",
                            CreatedDateTime = new DateTime(2023, 9, 4, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            GroupId = 1,
                            Title = "The anything event"
                        },
                        new
                        {
                            Id = 2,
                            Body = "Kräftskiva at my place.",
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

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

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
                            CreatedDate = new DateTime(2023, 9, 3, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 2,
                            ReplyToId = 1
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FunFact")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("WorkStatus")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarURL = "https://images.freeimages.com/images/large-previews/10e/halloween-skull-1-1309392.jpg",
                            Bio = "Studied a game programming at BTH.",
                            Email = "oscar@test.com",
                            FunFact = "I Have watched all shrek movies 10 times",
                            Name = "Oscar",
                            WorkStatus = "Employed"
                        },
                        new
                        {
                            Id = 2,
                            AvatarURL = "https://media.istockphoto.com/id/144219155/sv/foto/close-up-of-a-green-tree-frog-on-a-white-background.jpg?s=2048x2048&w=is&k=20&c=HB7twSjmtufkzMGJ1PvJ7YluR9oN7ZhD2wZQM1NMljU=",
                            Bio = "Studied Software Engineering at BTH",
                            Email = "simon@test.com",
                            FunFact = "I Love Chokladdoppade havreflarn.",
                            Name = "Simon",
                            WorkStatus = "Employed"
                        },
                        new
                        {
                            Id = 3,
                            AvatarURL = "https://media.istockphoto.com/id/1444396028/sv/foto/aland-islands-flag-pinned-white-background.jpg?s=2048x2048&w=is&k=20&c=PB9wGjejrjQeUonzDboZxRUrLuX9xp318lbyo_19vvI=",
                            Bio = "Studied web development at BTH",
                            Email = "erik@test.com",
                            FunFact = "I Can eat 19.61 sushi pieces in one sitting.",
                            Name = "Erik",
                            WorkStatus = "Employed"
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

            modelBuilder.Entity("AlumniAPI.Models.Group", b =>
                {
                    b.HasOne("AlumniAPI.Models.User", "Creator")
                        .WithMany("CreatedGroups")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
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
                    b.Navigation("CreatedGroups");

                    b.Navigation("Posts");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("Replies");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
