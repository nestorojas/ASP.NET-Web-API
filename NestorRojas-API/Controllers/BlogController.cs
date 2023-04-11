using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Entity.DataModel;
using Newtonsoft.Json;

namespace NestorRojas_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog/[Action]")]
    public class BlogController : Controller
    {
        private MyRepository.DataModel.IRepository _repository;
        public BlogController(MyRepository.DataModel.IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public List<Blog> GetBlogs()
        {
            return _repository.GetBlogs();
        }
        [HttpGet]
        public Blog ReadBlog(int Id)
        {
            return _repository.ReadBlog(Id);
        }
        [HttpPost]
        public bool CreateBlog()
        {
            Blog blog = new Blog();
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var data = reader.ReadToEndAsync().Result;
                blog = JsonConvert.DeserializeObject<Blog>(data);
            }
            return _repository.CreateBlog(blog);
        }
        [HttpPost]
        public bool UpdateBlog()
        {
            Blog blog = new Blog();
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var data = reader.ReadToEndAsync().Result;
                blog = JsonConvert.DeserializeObject<Blog>(data);
            }
            return _repository.UpdateBlog(blog);
        }
        [HttpPost]
        public bool DeleteBlog(int Id)
        {
            return _repository.DeleteBlog(Id);
        }
    }
}