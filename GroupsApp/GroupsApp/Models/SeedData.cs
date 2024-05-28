using GroupsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GroupsApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GroupsAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GroupsAppContext>>()))
            {
                if (context.TestMarketplacePost.Any())
                {
                    return;   // DB has been seeded
                }
                context.TestMarketplacePost.AddRange(
                    new TestMarketplacePost
                    {
                        Type = "TestType1",
                        Title = "sneakers",
                        Description = "good shoes"
                    },
                    new TestMarketplacePost
                    {
                        Type = "TestType2",
                        Title = "ipad",
                        Description = "good tablet"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
