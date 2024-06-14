using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext _dbContext;
        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(BloggieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            BlogPosts = _dbContext.BlogPosts.ToList();
        }
    }
}
