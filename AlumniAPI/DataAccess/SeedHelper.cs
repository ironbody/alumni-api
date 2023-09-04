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

    public static List<Post> GetPostSeeds()
    {
        var p1 = new Post()
        {
            Id = 1,
            CreatorId = 1,
            GroupId = 1,
            Title = "Ideas for the skibidi event",
            Body = "So we're having a skibidi event. If anyone have any good ideas, please write them down below.",
            CreatedDateTime = new DateTime(2023, 09, 04, 17, 0, 0),
        };

        
        var p2 = new Post()
        {
            Id = 2,
            CreatorId = 2,
            GroupId = 2,
            Title = "Kräftskiva",
            Body = "Kräftskiva at my place, BYOB",
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
}