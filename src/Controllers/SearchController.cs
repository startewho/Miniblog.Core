using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Miniblog.Core.Services;

namespace Miniblog.Core.Controllers
{
    public class SearchController : Controller
    {

        private readonly ILogger<SearchController> _logger;
        private readonly IBlogService _blog;
        private readonly IOptionsSnapshot<BlogSettings> _settings;
        public SearchController(IBlogService blog, ILogger<SearchController> logger, IOptionsSnapshot<BlogSettings> settings)
        {
            _logger = logger;
            _blog = blog;
            _settings = settings;
        }
        public async Task<IActionResult> Index([FromForm]string query="" )
        {
           
            int page = 0;
            var posts = await _blog.GetPostsByTitle(_settings.Value.PostsPerPage, query);
            ViewData["Title"] = _settings.Value.BlogName;
            ViewData["Description"] = "查询页结果";
            ViewData["prev"] = $"/{page + 1}/";
            ViewData["next"] = $"/{(page <= 1 ? null : page - 1 + "/")}";

            _logger.LogInformation($"访问了主页{DateTime.Now}");
            return View("~/Views/Blog/Index.cshtml", posts);
        }

      
    }
}