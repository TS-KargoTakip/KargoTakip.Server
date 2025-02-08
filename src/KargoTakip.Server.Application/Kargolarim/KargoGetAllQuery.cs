using KargoTakip.Server.Domain.Abstractions;
using KargoTakip.Server.Domain.Kargolarim;
using KargoTakip.Server.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KargoTakip.Server.Application.Kargolarim;
public sealed record KargoGetAllQuery(
    ) : IRequest<IQueryable<KargoGetAllQueryResponse>>;

public sealed class KargoGetAllQueryResponse : EntityDto
{
    public string GonderenFullName { get; set; } = default!;
    public string AliciFullName { get; set; } = default!;
    public string TeslimAdresiCity { get; set; } = default!;
    public string TeslimAdresiTown { get; set; } = default!;
    public string KargoTipiName { get; set; } = default!;
    public int Agirlik { get; set; }
    public string KargoDurumName { get; set; } = default!;
}

internal sealed class KargoGetAllQueryHandler(
    IKargoRepository kargoRepository,
    UserManager<AppUser> userManager
    ) : IRequestHandler<KargoGetAllQuery, IQueryable<KargoGetAllQueryResponse>>
{
    public Task<IQueryable<KargoGetAllQueryResponse>> Handle(KargoGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = (from entity in kargoRepository.GetAll()
                        join create_user in userManager.Users.AsQueryable() on entity.CreateUserId equals create_user.Id
                        join update_user in userManager.Users.AsQueryable() on entity.CreateUserId equals update_user.Id into update_user
                        from update_users in update_user.DefaultIfEmpty()
                        select new KargoGetAllQueryResponse
                        {
                            AliciFullName = entity.Alici.FirstName + " " + entity.Alici.LastName,
                            GonderenFullName = entity.Gonderen.FirstName + " " + entity.Gonderen.LastName,
                            Agirlik = entity.KargoInformation.Agirlik,
                            KargoTipiName = entity.KargoInformation.KargoTipi.Name,
                            TeslimAdresiCity = entity.TeslimAdresi.City,
                            TeslimAdresiTown = entity.TeslimAdresi.Town,
                            KargoDurumName = entity.KargoDurum.Name,
                            CreateAt = entity.CreateAt,
                            DeleteAt = entity.DeleteAt,
                            Id = entity.Id,
                            IsDeleted = entity.IsDeleted,
                            UpdateAt = entity.UpdateAt,
                            CreateUserId = entity.CreateUserId,
                            CreateUserName =
                                    create_user.FirstName + " " + create_user.LastName + " (" + create_user.Email + ")",
                            UpdateUserId = entity.UpdateUserId,
                            UpdateUserName =
                                    entity.UpdateUserId == null
                                    ? null
                                    : update_users.FirstName + " " + update_users.LastName + " (" + update_users.Email + ")",
                        });

        return Task.FromResult(response);
    }
}
