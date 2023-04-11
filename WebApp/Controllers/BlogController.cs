using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NestorRojas_Blog.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace NestorRojas_Blog.Controllers
{
    public class BlogController : Controller
    {
        IConfiguration _iconfiguration;
        public BlogController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            List<BlogViewModel> blog = await GetBlogs();
            
            return View(blog);
        }


        // GET: Blog/Details/5
        public async Task<IActionResult> ReadBlog(int Id)
        {
            BlogViewModel blog = await ReadBlog_API(Id);
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult CreateBlog()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(BlogViewModel model)
        {
            try
            {
                var result = await CreateBlog_API(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Result = "Blog was not created, please review";
                    return RedirectToAction(nameof(CreateBlog));

                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> EditBlog(int id)
        {
            BlogViewModel blog = await ReadBlog_API(id);
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(BlogViewModel model)
        {
            try
            {
                var result = await UpdateBlog_API(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Result = "Blog was not updated, please review";
                    return RedirectToAction(nameof(CreateBlog));

                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #region API Calls
        private async Task<List<BlogViewModel>> GetBlogs()
        {
            List<BlogViewModel> blog = new List<BlogViewModel>();
            var apiServerURL = _iconfiguration["ApiServer"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiServerURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync("api/Blog/GetBlogs");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<List<BlogViewModel>>(responseData);
                    response.Dispose();
                }
            }
            return blog;
        }
        private async Task<BlogViewModel> ReadBlog_API(int Id)
        {
            BlogViewModel blog = new BlogViewModel();
            var apiServerURL = _iconfiguration["ApiServer"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiServerURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string param = "?Id=" + Id;

                HttpResponseMessage response = await client.GetAsync("api/Blog/ReadBlog" + param);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<BlogViewModel>(responseData);
                    response.Dispose();
                }
            }
            return blog;
        }
        private async Task<bool> CreateBlog_API(BlogViewModel model)
        {
            bool result = false;
            var stringData = JsonConvert.SerializeObject(model);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var apiServerURL = _iconfiguration["ApiServer"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiServerURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.PostAsync("api/Blog/CreateBlog", contentData);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<bool>(responseData);
                    response.Dispose();
                }
            }
            return result;
        }
        private async Task<bool> UpdateBlog_API(BlogViewModel model)
        {
            bool result = false;
            var stringData = JsonConvert.SerializeObject(model);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var apiServerURL = _iconfiguration["ApiServer"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiServerURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.PostAsync("api/Blog/UpdateBlog", contentData);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<bool>(responseData);
                    response.Dispose();
                }
            }
            return result;
        }
        #endregion
    }
}