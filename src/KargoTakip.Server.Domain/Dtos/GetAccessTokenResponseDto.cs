using System.Text.Json.Serialization;

namespace KargoTakip.Server.Domain.Dtos;
public sealed class GetAccessTokenResponseDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
}
