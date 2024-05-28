using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Models;

namespace GroupsApp.Data
{
    public class GroupsAppContext : DbContext
    {
        public GroupsAppContext (DbContextOptions<GroupsAppContext> options)
            : base(options)
        {
        }

        public DbSet<GroupsApp.Models.TestMarketplacePost> TestMarketplacePost { get; set; } = default!;
        public DbSet<GroupsApp.Models.TestUser> TestUser { get; set; } = default!;
    }
}
