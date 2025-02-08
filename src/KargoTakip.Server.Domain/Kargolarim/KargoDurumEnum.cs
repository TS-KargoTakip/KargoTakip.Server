using Ardalis.SmartEnum;

namespace KargoTakip.Server.Domain.Kargolarim;

public sealed class KargoDurumEnum : SmartEnum<KargoDurumEnum>
{
    public static KargoDurumEnum Bekliyor = new("Bekliyor", 0);
    public static KargoDurumEnum AracaTeslimEdildi = new("Araca Teslim Edildi", 1);
    public static KargoDurumEnum YolaCikti = new("Yola Çıktı", 2);
    public static KargoDurumEnum TeslimSubesineUlasti = new("Teslim Şubesine Ulaştı", 3);
    public static KargoDurumEnum TeslimIcinYolaCikti = new("Teslim için Yola Çıktı", 4);
    public static KargoDurumEnum TeslimEdildi = new("Teslim Edildi", 5);
    public static KargoDurumEnum AdresteKimseBulunamadı = new("Adreste Kimse Bulunamadı", 6);
    public static KargoDurumEnum IptalEdildi = new("İptal Edildi", 7);
    public KargoDurumEnum(string name, int value) : base(name, value)
    {
    }
}
