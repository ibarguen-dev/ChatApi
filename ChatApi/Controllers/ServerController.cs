using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
