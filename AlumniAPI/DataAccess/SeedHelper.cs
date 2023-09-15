using AlumniAPI.Models;

namespace AlumniAPI.DataAccess;

public static class SeedHelper
{
    public static List<Post> GetPostSeeds()
    {
        var p1 = new Post()
        {
            Id = 1,
            CreatorId = 1,
            GroupId = 1,
            Title = "The anything event",
            Body = "So we're having a event. If anyone have any good ideas, please write them down below.",
            CreatedDateTime = new DateTime(2023, 09, 04, 17, 0, 0),
        };

        
        var p2 = new Post()
        {
            Id = 2,
            CreatorId = 2,
            GroupId = 2,
            Title = "Kräftskiva",
            Body = "Kräftskiva at my place.",
            CreatedDateTime = new DateTime(2023, 09, 03, 20, 0, 0),
        };

        var p3 = new Post()
        {
            Id = 3,
            CreatorId = 3,
            GroupId = 3,
            Title = "I love editing posts",
            Body = "Wow this post is edited. Isn't that crazy?",
            CreatedDateTime = new DateTime(2023, 09, 04, 15, 0, 0),
            EditedDateTime = new DateTime(2023, 09, 04, 16, 0, 0),
        };

        return new List<Post>()
        {
            p1,
            p2,
            p3,
        };
    }

    public static List<EventInfo> GetEventInfoSeeds()
    {
        var startDate1 = new DateTime(2023, 09, 10, 18, 0, 0);
        var endDate1 = startDate1.AddHours(4);
        var e1 = new EventInfo()
        {
            Id = 1,
            PostId = 2,
            Start = startDate1,
            End = endDate1,
            Location = "My place"
        };

        return new List<EventInfo>()
        {
            e1,
        };
    }

    public static List<Reply> GetReplySeed()
    {
        var r1 = new Reply()
        {
            Id = 1,
            CreatorId = 2,
            ReplyToId = 1,
            CreatedDate = new DateTime(2023, 09, 03, 21, 0, 0),
            Body = "I think we should have drinks and scooby snacks"
        };

        return new List<Reply>()
        {
            r1,
        };
    }

    public static List<User> GetUserSeeds()
    {
        return new List<User>()
        {
            new User()
            {
                Id = 1,
                Name = "Oscar",
                Email = "oscar@test.com",
                AvatarURL = "https://images.freeimages.com/images/large-previews/10e/halloween-skull-1-1309392.jpg",
                Bio = "Studied a game programming at BTH.",
                FunFact = "I Have watched all shrek movies 10 times",
                WorkStatus = "Employed"
            },
            new User()
            {
                Id = 2,
                Name = "Simon",
                Email = "simon@test.com",
                AvatarURL = "https://media.istockphoto.com/id/144219155/sv/foto/close-up-of-a-green-tree-frog-on-a-white-background.jpg?s=2048x2048&w=is&k=20&c=HB7twSjmtufkzMGJ1PvJ7YluR9oN7ZhD2wZQM1NMljU=",
                Bio = "Studied Software Engineering at BTH",
                FunFact = "I Love Chokladdoppade havreflarn.",
                WorkStatus = "Employed"
            },
            new User()
            {
                Id = 3,
                Name = "Erik",
                Email = "erik@test.com",
                AvatarURL = "https://media.istockphoto.com/id/1444396028/sv/foto/aland-islands-flag-pinned-white-background.jpg?s=2048x2048&w=is&k=20&c=PB9wGjejrjQeUonzDboZxRUrLuX9xp318lbyo_19vvI=",
                Bio = "Studied web development at BTH",
                FunFact = "I Can eat 19.61 sushi pieces in one sitting.",
                WorkStatus = "Employed"
            }
            
        };
    }

    public static List<DirectMessage> GetMessageSeeds()
    {
        return new List<DirectMessage>()
        {
            new DirectMessage()
            {
                Id = 1,
                Body = "Hello Erik, how did you eat soo many pieces in one sitting???",
                SentTime = new DateTime(2023,9,4,9,4,32),
                SenderId = 1,
                RecipientId = 3
            },
            new DirectMessage()
            {
                Id = 2,
                Body = "It was easy, I just did it.",
                SentTime = new DateTime(2023,9,4,9,4,57),
                SenderId = 3,
                RecipientId = 1
            },
            new DirectMessage()
            {
                Id = 3,
                Body = "Wow, very cool!",
                SentTime = new DateTime(2023,9,4,9,5,50),
                SenderId = 1,
                RecipientId = 3
            },
            new DirectMessage()
            {
                Id = 4,
                Body = "Hello Simon, how are you?",
                SentTime = new DateTime(2023,9,4,9,4,32),
                SenderId = 1,
                RecipientId = 2
            },
            new DirectMessage()
            {
                Id = 5,
                Body = "Hey Oscar! Good, I just ate 10 havreflarn!",
                SentTime = new DateTime(2023,9,4,9,4,32),
                SenderId = 2,
                RecipientId = 3
            }
        };
    }

    public static List<Group> GetGroupSeeds()
    {
        return new List<Group>()
        {
            new Group()
            {
                Id = 1,
                Name = "Kayakers",
                Description = "Group for people who lowes kayaking.",
                CreatorId = 1,
                Private = false,
            },
            new Group()
            {
                Id = 2,
                Name = "Karaoke Nights",
                Description = "Group for people who want to sing karaoke.",
                CreatorId = 2,
                Private = false,
            },
            new Group()
            {
                Id = 3,
                Name = "Spongebob Fanatics",
                Description = "Group for people who LOVE spongebob",
                CreatorId = 3,
                Private = false,
            }
        };
    }

    public static List<UserGroup> GetUserGroupSeeds()
    {
        return new List<UserGroup>()
        {
            new UserGroup()
            {
                UserId = 1,
                GroupId = 1
            },
            new UserGroup()
            {
                UserId = 2,
                GroupId = 2
            },
            new UserGroup()
            {
                UserId = 3,
                GroupId = 3
            }
        };
    }
}