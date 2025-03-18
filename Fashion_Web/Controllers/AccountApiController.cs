using Fashion_Web.Models;
using Fashion_Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Fashion_Web.Services;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Web.Controllers
{
    [Route("api/acc")]
    [ApiController]
    public class AccountApiController : Controller
    {
        private readonly QLBanDoThoiTrangContext _context;
        public AccountApiController(QLBanDoThoiTrangContext context)
        {
            _context = context;
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuthentication");
            return Ok();
        }

    }
}
