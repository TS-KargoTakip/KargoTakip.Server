using KargoTakip.Server.Application.Kargolarim;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace KargoTakip.Server.WebAPI.Controllers;

[Route("odata")]
[ApiController]
[EnableQuery]
public class AppODataController(
    ISender sender
    ) : ODataController
{
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new();
        builder.EnableLowerCamelCase();
        builder.EntitySet<KargoGetAllQueryResponse>("kargolar");
        return builder.GetEdmModel();
    }

    [HttpGet("kargolar")]
    public async Task<IQueryable<KargoGetAllQueryResponse>> GetAllEmployees(CancellationToken cancellationToken)
    {
        var response = await sender.Send(new KargoGetAllQuery(), cancellationToken);
        return response;
    }
}
