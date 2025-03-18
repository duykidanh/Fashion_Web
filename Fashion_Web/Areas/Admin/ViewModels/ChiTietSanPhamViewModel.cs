using Fashion_Web.Models;

namespace Fashion_Web.ViewModels
{
    public class ChiTietSanPhamViewModel
    {
        public TDanhMucSp Sp { get; set; }

        public List<TChiTietSanPham> chiTietSanPhams { get; set; }
    }
}
