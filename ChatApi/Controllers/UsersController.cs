using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;

namespace ChatApi.Controllers
{
    [Route("controller")]
    [ApiController]
    public class UsersController : Controller
    {
        public readonly DbChatContext _chatContext;
        public UsersController(DbChatContext _context) {
            _chatContext = _context;    
        }
        [Route("create/")]
        [HttpPost]
        public IActionResult Create(User ouser)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, new { menssage = "oh", reponse = "exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "error", response = ex });
            }
        }

        [Route("login/")]
        [HttpPost]
        public IActionResult Login(User ouser)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = "exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "error", response = ex });
            }

        }
    }
}
