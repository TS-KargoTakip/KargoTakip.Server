using KargoTakip.Server.Domain.Users;

namespace KargoTakip.Server.Application.Services;
public interface IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user, string password, CancellationToken cancellationToken = default);
}
