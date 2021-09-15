using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedeSocial.Mvc.Models.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedeSocial.Mvc.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            HttpClient postman = new HttpClient();
            var resultado = await postman.GetAsync("https://localhost:44357/api/posts");
            var postsJson = await resultado.Content.ReadAsStringAsync();
            List<PostModel> posts = JsonConvert.DeserializeObject<List<PostModel>>(postsJson);
            viewModel.Posts = posts;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(string title, string text, IFormFile imagem)
        {
            var fileForm = this.Request.Form.Files[0];
            MemoryStream ms = new MemoryStream();
            fileForm.CopyTo(ms);
            ms.Position = 0;
            String azureBlobStorageConnection = "DefaultEndpointsProtocol=https;AccountName=projetoblocostorage;AccountKey=cDK7hsLzDN85PDqw9o8hR+PBJG+7nO85EU6Tssd9kk6ll+kTsxz7OB1hf697R11d3/+qvu0WVDsaqeAxOyrjrw==;EndpointSuffix=core.windows.net";
            BlobServiceClient blobServiceClient = new BlobServiceClient(azureBlobStorageConnection);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("images");
            //var fileName = "file_" + Guid.NewGuid() + fileForm.FileName;
            BlobClient blobClient = containerClient.GetBlobClient(fileForm.FileName);
            blobClient.Upload(ms);
            // Blob
            HttpClient postman = new HttpClient();
            var createPost = new
            {
                Title = title,
                Text = text,
                Img = fileForm.FileName,
                Author = ""
            };
            var postAsJson = JsonConvert.SerializeObject(createPost);
            var conteudo = new StringContent(postAsJson, System.Text.Encoding.UTF8, "application/json");
            await postman.PostAsync("https://localhost:44357/api/posts", conteudo);
            return RedirectToAction("Index");
        }
    }
}
