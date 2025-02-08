using KargoTakip.Server.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace KargoTakip.Server.WebAPI;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    Id = Guid.Parse("250b0664-17c1-4a21-976e-795515c7d5b1"),
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Taner",
                    LastName = "Saydam",
                    EmailConfirmed = true,
                    CreateAt = DateTimeOffset.Now,
                };

                user.CreateUserId = user.Id;

                userManager.CreateAsync(user, "1").Wait();


            }
        }
    }
}
