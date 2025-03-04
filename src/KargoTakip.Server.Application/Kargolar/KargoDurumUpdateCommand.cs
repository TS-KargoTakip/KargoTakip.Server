using FluentValidation;
using GenericRepository;
using KargoTakip.Server.Domain.Kargolar;
using KargoTakip.Server.Domain.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.Application.Kargolar;

public sealed record KargoDurumUpdateCommand(
    Guid Id,
    int DurumValue) : IRequest<Result<string>>;

public sealed class KargoDurumUpdateCommandValidator : AbstractValidator<KargoDurumUpdateCommand>
{
    public KargoDurumUpdateCommandValidator()
    {
        RuleFor(p => p.DurumValue)
            .GreaterThanOrEqualTo(0).WithMessage("Geçerli bir kargo durumu seçin")
            .LessThan(7).WithMessage("Geçerli bir kargo durumu seçin");
    }
}

internal sealed class KargoDurumUpdateCommandHandler(
    IKargoRepository kargoRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<KargoDurumUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoDurumUpdateCommand request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
        {
            return Result<string>.Failure("Kargo bulunamadı");
        }
        kargo.KargoDurum = (KargoDurumEnum)request.DurumValue;
        kargoRepository.Update(kargo);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kargo durumu başarıyla güncellendi";
    }
}
