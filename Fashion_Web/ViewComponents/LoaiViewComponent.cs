using Fashion_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fashion_Web.ViewComponents
{
    public class LoaiViewComponent : ViewComponent
    {
        QLBanDoThoiTrangContext _context;
        public LoaiViewComponent(QLBanDoThoiTrangContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiList = _context.TDanhMucSps.Select(d => d.LoaiDt).Distinct().ToList();
            return View("RenderLoai", loaiList);
        }
    }
}
