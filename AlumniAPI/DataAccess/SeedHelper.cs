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
}