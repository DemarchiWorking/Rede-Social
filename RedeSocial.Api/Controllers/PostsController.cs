using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedeSocial.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : Controller
    {
        [HttpPost]
        public IActionResult Post(GetPostResponse request)
        {
            posts.Add(new GetPostResponse
            {
                Img = request.Img,
                Text = request.Text,
                Title = request.Title,
                Author = User.Identity.Name
            }) ;
            return Ok();
        }
        static List<GetPostResponse> posts = new List<GetPostResponse>();
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(posts);
        }
    }
}
