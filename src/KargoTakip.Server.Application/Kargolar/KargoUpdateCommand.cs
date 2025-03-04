using FluentValidation;
using GenericRepository;
using KargoTakip.Server.Domain.Kargolar;
using KargoTakip.Server.Domain.Kargolarim;
using Mapster;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.Application.Kargolar;

public sealed record KargoUpdateCommand(
    Guid Id,
    Person Gonderen,
    Person Alici,
    Address TeslimAdresi,
    KargoInformationDto KargoInformation) : IRequest<Result<string>>;

public sealed class KargoUpdateCommandValidator : AbstractValidator<KargoUpdateCommand>
{
    public KargoUpdateCommandValidator()
    {
        RuleFor(p => p.Gonderen.FirstName).NotEmpty().WithMessage("Geçerli bir gönderen adı girin");
        RuleFor(p => p.Gonderen.LastName).NotEmpty().WithMessage("Geçerli bir gönderen soyadı girin");
        RuleFor(p => p.Alici.FirstName).NotEmpty().WithMessage("Geçerli bir alıcı adı girin");
        RuleFor(p => p.Alici.LastName).NotEmpty().WithMessage("Geçerli bir alıcı soyadı girin");
        RuleFor(p => p.TeslimAdresi.City).NotEmpty().WithMessage("Geçerli bir şehir girin");
        RuleFor(p => p.TeslimAdresi.Town).NotEmpty().WithMessage("Geçerli bir ilçe girin");
        RuleFor(p => p.TeslimAdresi.Mahalle).NotEmpty().WithMessage("Geçerli bir mahalle girin");
        RuleFor(p => p.TeslimAdresi.FullAddress).NotEmpty().WithMessage("Geçerli bir tam adres girin");
        RuleFor(p => p.KargoInformation.KargoTipiValue)
            .GreaterThanOrEqualTo(0).WithMessage("Geçerli bir kargo tipi seçin")
            .LessThan(KargoTipiEnum.List.Count()).WithMessage("Geçerli bir kargo tipi seçin");
    }
}

internal sealed class KargoUpdateCommandHandler(
    IKargoRepository kargoRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<KargoUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoUpdateCommand request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
        {
            return Result<string>.Failure("Kargo bulunamadı");
        }

        if (kargo.KargoDurum != KargoDurumEnum.Bekliyor)
        {
            return Result<string>.Failure("Sadece bekleyen kargoları güncelleyebilirsiniz");
        }

        request.Adapt(kargo);
        KargoInformation kargoInformation = new()
        {
            KargoTipi = KargoTipiEnum.FromValue(request.KargoInformation.KargoTipiValue),
            Agirlik = request.KargoInformation.Agirlik
        };
        kargo.KargoInformation = kargoInformation;
        kargo.Alici = request.Alici;
        kargo.Gonderen = request.Gonderen;
        kargoRepository.Update(kargo);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        //to do: burada mail veya sms gönderme işlemleri yapılacak
        //to do: ileride notification içinde domain event kullanabiliriz

        return "Kargo başarıyla güncellendi";
    }
}
