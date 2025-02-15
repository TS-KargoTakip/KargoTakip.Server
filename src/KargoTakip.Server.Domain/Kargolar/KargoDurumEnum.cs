using System.ComponentModel.DataAnnotations;

namespace KargoTakip.Server.Domain.Kargolarim;

public enum KargoDurumEnum
{
    [Display(Name = "Bekliyor")]
    Bekliyor = 0,

    [Display(Name = "Araca Teslim Edildi")]
    AracaTeslimEdildi = 1,

    [Display(Name = "Yola Çıktı")]
    YolaCikti = 2,

    [Display(Name = "Teslim Şubesine Ulaştı")]
    TeslimSubesineUlasti = 3,

    [Display(Name = "Teslim İçin Yola Çıktı")]
    TeslimIcinYolaCikti = 4,

    [Display(Name = "Teslim Edildi")]
    TeslimEdildi = 5,

    [Display(Name = "Adreste Kimse Bulunamadı")]
    AdresteKimseBulunamadi = 6,

    [Display(Name = "İptal Edildi")]
    IptalEdildi = 7
}
