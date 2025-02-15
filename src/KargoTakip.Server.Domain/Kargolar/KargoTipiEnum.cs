using Ardalis.SmartEnum;

namespace KargoTakip.Server.Domain.Kargolarim;

public sealed class KargoTipiEnum : SmartEnum<KargoTipiEnum>
{
    public static KargoTipiEnum Paket = new("Paket", 0);
    public static KargoTipiEnum Zarf = new("Zarf", 1);
    public static KargoTipiEnum Koli = new("Koli", 2);
    public KargoTipiEnum(string name, int value) : base(name, value)
    {
    }
}
