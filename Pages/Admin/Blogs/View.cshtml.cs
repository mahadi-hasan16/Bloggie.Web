using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ViewModel : PageModel
    {
        private readonly BloggieDbContext _dbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public ViewModel(BloggieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost = await _dbContext.BlogPosts.FindAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var blogPost = _dbContext.BlogPosts.Find(BlogPost.Id);

            blogPost.Heading = BlogPost.Heading;
            blogPost.PageTitle = BlogPost.Heading;
            blogPost.Content = BlogPost.Content;
            blogPost.ShortDescription = BlogPost.ShortDescription;
            blogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
            blogPost.UrlHandle = BlogPost.UrlHandle;
            blogPost.Visible = BlogPost.Visible;

            await _dbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var blogPost = await _dbContext.BlogPosts.FindAsync(BlogPost.Id);

            _dbContext.BlogPosts.Remove(blogPost);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
