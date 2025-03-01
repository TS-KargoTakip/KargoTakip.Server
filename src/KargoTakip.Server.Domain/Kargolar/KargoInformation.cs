using KargoTakip.Server.Domain.Kargolarim;

namespace KargoTakip.Server.Domain.Kargolar;

public sealed record KargoInformation
{
    public KargoTipiEnum KargoTipi { get; set; } = default!;
    public int KargoTipiValue => KargoTipi.Value;
    public int Agirlik { get; set; }
};
