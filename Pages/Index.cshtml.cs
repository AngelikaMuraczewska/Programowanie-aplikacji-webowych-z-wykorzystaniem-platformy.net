using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRapp.Pages
{
    public class IndexModel : PageModel
    {
        public Credential Credential { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }

    public class Credential
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}