using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecordingApp.Models;

namespace RecordingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Record()
        {
            return View();
        }
		
		[HttpPost]
		public async Task<IActionResult> SaveRecording(string filename)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "RecordedFiles", filename);
        
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
            await Request.Body.CopyToAsync(stream);
			}

			return Ok();
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
    }
}
