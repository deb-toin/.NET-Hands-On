using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Basic_ASPNET_API_example.Pages;

public class PetshopListModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public PetshopListModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
