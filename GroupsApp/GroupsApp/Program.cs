using GroupsApp.Data;
using GroupsApp.Models;
using GroupsApp.Repositories;
using GroupsApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroupsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<GroupsAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GroupsAppContext") ?? throw new InvalidOperationException("Connection string 'GroupsAppContext' not found.")));


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<GroupsAppContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            //builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            //builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEventService, EventService>();
            //builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IUserEventRepository, UserEventRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IAuctionPostRepository, AuctionPostRepository>();
            builder.Services.AddScoped<IMarketplacePostRepository, MarketplacePostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUsersFavouritePostsRepository, UsersFavouritePostsRepository>();
            builder.Services.AddScoped<IDonationPostRepository, DonationPostRepository>();
            builder.Services.AddScoped<IEventReportRepository, EventReportRepository>();
            builder.Services.AddScoped<IEventReviewRepository, EventReviewRepository>();
            builder.Services.AddScoped<IFixedPricePostRepository, FixedPricePostRepository>();
            builder.Services.AddScoped<IGroupPostReportRepository, GroupPostReportRepository>();
            builder.Services.AddScoped<IJoinRequestRepository, JoinRequestRepository>();
            builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
            builder.Services.AddScoped<InterestStatusRepository>();
            builder.Services.AddScoped<IPollAnswerRepository, PollAnswerRepository>();
            builder.Services.AddScoped<IPollRepository, PollRepository>();
            builder.Services.AddScoped<IPollOptionRepository, PollOptionRepository>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                //SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
