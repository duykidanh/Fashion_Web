using Fashion_Web.Models;
using Fashion_Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using X.PagedList;

namespace Fashion_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLBanDoThoiTrangContext db;
        private readonly ILogger<HomeController> _logger;
        private int pageSize = 9;

        public HomeController(ILogger<HomeController> logger, QLBanDoThoiTrangContext doThoiTrangContext)
        {
            _logger = logger;
            db = doThoiTrangContext;
        }

        public IActionResult Home()
        {
            var lst = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp).Take(5);
            return View("Home", lst);
        }

        public IActionResult Index()
        {
            var Sp = db.TDanhMucSps.AsQueryable();
            int pageNum = (int)Math.Ceiling(Sp.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            ViewBag.keyword = "";
            var result = Sp.Take(pageSize).ToList();
            return View(result);
        }
        public IActionResult LocSanPham(string? keyword, int? pageIndex)
        {
            var sp = db.TDanhMucSps.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                sp = sp.Where(l => l.TenSp.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int page = (pageIndex ?? 1);
            int pageNum = (int)Math.Ceiling(sp.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = sp.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return PartialView("BangSanPhamHome", result);
        }
        public IActionResult SanPhamTheoLoai(string Loai, int? Page)
        {
            int pageSize = 9;
            int pageNumber = Page == null || Page <= 0 ? 1 : Page.Value;
            var list = db.TDanhMucSps.AsNoTracking().Where(x => x.LoaiDt == Loai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(list, pageNumber, pageSize);
            ViewBag.Loai = Loai;
            return View(lst);
        }
        public IActionResult ChiTietSp(int MaSP)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == MaSP);
            var anhSp = db.TAnhSps.Where(x => x.MaSp == MaSP).ToList();
            ViewBag.AnhSP = anhSp;
            return View(sp);
        }

        public IActionResult ChiTietSpNew(int MaSP)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == MaSP);
            var anhSp = db.TAnhSps.Where(x => x.MaSp == MaSP).ToList();
            var sizes = db.TChiTietSanPhams
                              .Where(x => x.MaSp == MaSP)
                              .Select(x => x.KichThuoc)
                              .Distinct() 
                              .ToList();
            var colors = db.TChiTietSanPhams
                              .Where(x => x.MaSp == MaSP)
                              .Select(x => x.MauSac)
                              .Distinct()
                              .ToList();
            HomeProductDetailViewModel model = new HomeProductDetailViewModel
            {
                product = sp,
                productImages = anhSp,
                Sizes = sizes,
                Colors = colors
            };

            return View(model);
        }
        public IActionResult TimSanPham(string Tensanpham, int? Page)
        {
            int pageSize = 9;
            int pageNumber = Page == null || Page <= 0 ? 1 : Page.Value;
            var list = db.TDanhMucSps.AsNoTracking().Where(x => x.TenSp.Contains(Tensanpham)).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(list, pageNumber, pageSize);
            ViewBag.Tensanpham = Tensanpham;
            return View(lst);
        }
        public IActionResult SanPhamTheoGia(int Gia, int? Page)
        {

                var list = db.TDanhMucSps.AsNoTracking().Where(x => x.Gia <= Gia).OrderBy(x => x.Gia).ToList();
                int pageSize = 9;
                int pageNumber = Page == null || Page <= 0 ? 1 : Page.Value;
                PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(list, pageNumber, pageSize);
                ViewBag.Gia = Gia;
                return View(lst);
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
