using  WebRestfulApiEx.Models;

namespace WebRestfulApiEx.ViewModels
{
    public class BlogPostVM
    {
        public List<Blog>? listBlog { get; set; }
        public string Msg { get; set; }

        public BlogPostVM()
        { 
        
        }

    }
}
