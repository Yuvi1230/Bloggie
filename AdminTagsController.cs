using Bloogieapp.Data;
using Bloogieapp.Models.Domain;
using Bloogieapp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloogieapp.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext=bloggieDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest){
            var tag=new Tag{
                Name=addTagRequest.Name,
                DisplayName= addTagRequest.DisplayName
            };
          bloggieDbContext.Tags.Add(tag);
          bloggieDbContext.SaveChanges();
           return View("Add");
        }

    }
}
