using AlumniAPI.Models;

namespace AlumniAPI.DataAccess;

public static class SeedHelper
{
    public static List<Test> GetTestSeeds()
    {
        return new List<Test>()
        {
            new Test()
            {
                Id = 1, Name = "Oscar"
            },
            new Test()
            {
                Id = 2, Name = "Simon"
            },
            new Test()
            {
                Id = 3, Name = "Erik"
            },
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
                AvatarURL = "https://temashopse.b-cdn.net/media/catalog/product/cache/cat_resized/1200/0/s/h/shrek_r_maskeraddrakt_maskeraddrakter_maskeradklader_for_man.jpg",
                Bio = "Shrek/Kong lover",
                FunFact = "Loves Shrek and Kong",
            },
            new User()
            {
                Id = 2,
                Name = "Simon",
                AvatarURL = "https://preview.redd.it/ufc-fight-night-shrek-vs-adam-sandler-v0-d3r78jgnhmv91.jpg?width=512&format=pjpg&auto=webp&s=2f93c0115d58a24e638a69f0a21fc571da99ac55",
                Bio = "Hello I'm Simon and I love HAVREFLARN med choklad",
                FunFact = "Cookie lover XD",
            },
            new User()
            {
                Id = 3,
                Name = "Erik",
                AvatarURL = "https://pbs.twimg.com/profile_images/1342617687663521793/4lVjmcIk_400x400.jpg",
                Bio = "Erik aka MuminLover1337",
                FunFact = "I LOVE MUUUUMIN!",
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
                Body = "Hello Mr.Moomin how are you?",
                SentTime = new DateTime(2023,9,4,9,4,32),
                SenderId = 1,
                RecipientId = 3
            },
            new DirectMessage()
            {
                Id = 2,
                Body = "Hey, im a bit depressed. I might need a kong strong...",
                SentTime = new DateTime(2023,9,4,9,4,57),
                SenderId = 3,
                RecipientId = 1
            },
            new DirectMessage()
            {
            Id = 3,
            Body = "lol",
            SentTime = new DateTime(2023,9,4,9,5,50),
            SenderId = 1,
            RecipientId = 3
            },
            new DirectMessage()
            {
                Id = 4,
                Body = "blablabla",
                SentTime = new DateTime(2023,9,4,9,4,32),
                SenderId = 1,
                RecipientId = 2
            },
            new DirectMessage()
            {
                Id = 5,
                Body = "blablabla",
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
            },
            new Group()
            {
                Id = 2,
                Name = "Kareoke Nights",
                Description = "Group for people who want to sing kareoke.",
            },
            new Group()
            {
                Id = 3,
                Name = "Spongebob Fanatics",
                Description = "Group for people who LOVE spongebob",
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