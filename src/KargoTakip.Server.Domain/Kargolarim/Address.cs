namespace KargoTakip.Server.Domain.Kargolarim;

public sealed record Address( //value object
    string City,
    string Town,
    string Mahalle,
    string Street,
    string FullAddress);
