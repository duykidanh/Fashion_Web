using Fashion_Web.Models;
using Fashion_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_Web.Controllers
{
    public class GiamGiaController : Controller
    {
        private readonly QLBanDoThoiTrangContext _context;

        public GiamGiaController(QLBanDoThoiTrangContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
