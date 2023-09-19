using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("controller")]
    [ApiController]
    public class ServerController : Controller
    {
        private readonly string cadena;
        public ServerController(IConfiguration config)
        {
            cadena = config.GetConnectionString("cadenaConexion");
        }

        [Route("list")]
        [HttpGet]
        public IActionResult ListServer()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                return View();
            }
        }
    }
}
