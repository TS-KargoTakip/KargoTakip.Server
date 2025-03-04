using GenericRepository;
using KargoTakip.Server.Domain.Kargolar;
using KargoTakip.Server.Domain.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.Application.Kargolar;

public sealed record KargoDeleteCommand(
Guid Id) : IRequest<Result<string>>;

internal sealed class KargoDeleteCommandHandler(
    IKargoRepository kargoRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<KargoDeleteCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoDeleteCommand request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
        {
            return Result<string>.Failure("Kargo bulunamadı");
        }

        if (kargo.KargoDurum != KargoDurumEnum.Bekliyor)
        {
            return Result<string>.Failure("Sadece bekleyen kargoları silebilirsiniz");
        }

        kargo.IsDeleted = true;
        kargoRepository.Update(kargo);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kargo başarıyla silindi";
    }
}