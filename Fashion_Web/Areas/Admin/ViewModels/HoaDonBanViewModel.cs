using Fashion_Web.Models;

namespace Fashion_Web.ViewModels
{
    public class HoaDonBanViewModel
    {
        public List<TDanhMucSp> danhMucSp { get; set; }
        public THoaDonBan hoaDon { get; set; }
        
        public TChiTietHoaDonBan chiTietHoaDon { get; set; }

        public TMaGiamGia maGiamGia { get; set; }

        public decimal? doanhThuNam { get; set; }
        public decimal? doanhThuThangNay { get; set; }
        public decimal? doanhThuThangTruoc { get; set; }
        public decimal? doanhThuThangTruoc1 { get; set; }

    }
}
