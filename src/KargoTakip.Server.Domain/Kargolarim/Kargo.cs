using KargoTakip.Server.Domain.Abstractions;

namespace KargoTakip.Server.Domain.Kargolarim;
public sealed class Kargo : Entity
{
    public Person Gonderen { get; set; } = default!;
    public Person Alici { get; set; } = default!;
    public Address TeslimAdresi { get; set; } = default!;
    public KargoInformation KargoInformation { get; set; } = default!;
    public KargoDurumEnum KargoDurum { get; set; } = default!;
}