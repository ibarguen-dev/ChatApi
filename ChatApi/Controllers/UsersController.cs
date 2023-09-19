using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;
using ChatApi.Data;
namespace ChatApi.Controllers
{
    [Route("controller")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly string cadena;
        public UsersController(IConfiguration config)
        {

          cadena =  config.GetConnectionString("cadenaConexion");
        }

        [Route("create/")]
        [HttpPost]
        public IActionResult Create(UserModel ouser)
        {
            UserData userData = new UserData(cadena);
            
            try
            {
                bool users;

                users = userData.creteUser(ouser);
                if (users == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "error", response = "Hubo un error al momento de crear el usuario" });
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = "Usuario creado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "error", response = ex });
            }
        }

        [Route("login/")]
        [HttpPost]
        public IActionResult Login(UserModel ouser)
        {
            UserData userData = new UserData(cadena); 
            try
            {

                List<UserModel> users = new List<UserModel>();
                users = userData.login(ouser);
                if (users.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "error", response = "Usuario o contraseña son incorrectos" });
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = users });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "error", response = ex });
            }

        }
    }
}
