using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRapp.Pages
{
    public class PracownicyModel : PageModel
    {
        private readonly ILogger<PracownicyModel> _logger;

        public PrivacyModel(ILogger<PracownicyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}