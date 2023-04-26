using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NestorRojas_Blog.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Entity.DataModel;

namespace NestorRojas_Blog.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _iconfiguration;
        public HomeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public IActionResult Index()
        {
            var data = GetAllRecords().Result;
            ViewBag.datasource = data;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<List<Blog>> GetAllRecords()
        {
            List<Blog> blog = new();
            var apiServerURL = _iconfiguration["ApiServer"];
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(apiServerURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Blog/GetBlogs");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<List<Blog>>(responseData);
                    response.Dispose();
                }
            }
            catch
            {
                throw;
            }

            return blog;
        }
    }
}
