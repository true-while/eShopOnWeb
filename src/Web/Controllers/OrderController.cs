using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using Microsoft.FeatureManagement;

namespace Microsoft.eShopWeb.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
[Route("[controller]/[action]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    private readonly IFeatureManager _featureManager;
    static TelemetryClient telemetryClient = new TelemetryClient() { InstrumentationKey = "d9657adf-ffae-48cb-8f08-e676f16905ea" };

    public OrderController(IMediator mediator, IFeatureManager featureManagement)
    {
        _mediator = mediator;
        _featureManager = featureManagement;    
    }

    [HttpGet]
    public async Task<IActionResult> MyOrders()
    {

        var viewModel = await _mediator.Send(new GetMyOrders(User.Identity.Name));

        return View(viewModel);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> Detail(int orderId)
    {
        var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

        if (viewModel == null)
        {
            return BadRequest("No such order found for this user.");
        }

        return View(viewModel);
    }
}
