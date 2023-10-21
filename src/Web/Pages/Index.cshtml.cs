using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;

namespace Microsoft.eShopWeb.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICatalogViewModelService _catalogViewModelService;
    private IFeatureManager _featureManager;
    public SettingsViewModel SettingsModel { get; }

    public IndexModel(ICatalogViewModelService catalogViewModelService, IFeatureManager featureManager, IOptionsSnapshot<SettingsViewModel> options)
    {
        _catalogViewModelService = catalogViewModelService;
        SettingsModel = options.Value;
        _featureManager = featureManager;
    }

    public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

    public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
    {


        if (await _featureManager.IsEnabledAsync("black-friday"))
        {
            //set up empty list
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, 0, catalogModel.TypesFilterApplied);

            //add black Friday deal
            CatalogModel.CatalogItems.Clear();
            CatalogModel.CatalogItems.Add(new CatalogItemViewModel()
            {
                Id = 0,
                Name = "Hot Black Friday Deal 70%",
                PictureUri = "https://th.bing.com/th/id/OIP.LLJAuXX83OJFSHj-Lr8voAHaEL?w=307&h=180&c=7&r=0&o=5&dpr=1.1&pid=1.7",
                Price = 9.99M

            });
            CatalogModel.PaginationInfo.TotalItems = 1;
            CatalogModel.PaginationInfo.TotalPages = 1;
        }
        else
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);

        }



    }
}
