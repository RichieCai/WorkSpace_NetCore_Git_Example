using Microsoft.AspNetCore.Mvc;
using WebRestfulApiEx.Models;
using WebRestfulApiEx.Data;
using WebRestfulApiEx.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebRestfulApiEx.Controllers
{
    public class BlogController : Controller
    {
        private readonly CustomDbSampleContext context;
        //private readonly ILogger<DeleteModel> _logger;
        public BlogController(CustomDbSampleContext pcontext)
        {
            context = pcontext;
            //_logger = logger;
        }

        [HttpGet]
        [Route("/")]
        public IEnumerable<Blog> Index()
        {
            //var blog = await context.Blog.ToListAsync();
            List<Blog> listBlog = context.Blog.ToList();

            return listBlog.ToArray();
        }

        [HttpPost]
        [Route("/Show")]
        public BlogPostVM Show(Blog blog)
        {
            BlogPostVM bvm = new BlogPostVM();
            try
            {
                context.Blog.Add(blog);
                //await  context.SaveChangesAsync();
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                bvm.Msg= ex.Message.ToString();
            }
            List<Blog> listBlog = context.Blog.ToList();
            bvm.listBlog = listBlog;

            return bvm;
        }


        [HttpPut]
        [Route("/Edit")]
        public IEnumerable<Blog> Edit(Blog blog)
        {
            //FindAsync

            //方法1
            context.Blog.Update(blog);
            context.SaveChanges();

            //方法2
            //context.Entry(blog).State = EntityState.Modified;
            //context.SaveChanges();
            //List<Blog> listBlog = context.Blog.Where(t => t.BlogId== id).ToList();
            List<Blog> listBlog = context.Blog.ToList();
            return listBlog.ToArray();
        }

        [HttpDelete]
        [Route("/Delete")]
        public IEnumerable<Blog> Delete(Blog blog)
        {
            //方法1
            Blog blogResult = context.Blog.FirstOrDefault(x => x.BlogId == blog.BlogId);
            context.Blog.Remove(blogResult);
            context.SaveChanges();

            //方法2
            //Blog blogResult2 = context.Blog.Single(x => x.BlogId == blog.BlogId);
            //context.Entry(blogResult2).State = EntityState.Deleted;
            //context.SaveChanges();


            List<Blog> listBlog = context.Blog.ToList();
            return listBlog.ToArray();
        }
    }
}
