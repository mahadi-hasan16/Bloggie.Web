using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var heading = Request.Form["heading"];
            Console.WriteLine(heading);
        }
    }
}
