using Fashion_Web.Models;

namespace Fashion_Web.ViewModels
{
    public class CheckoutViewModel
    {

        public IEnumerable<TGioHang> CartItems { get; set; }
        public TKhachHang CustomerInfo { get; set; }
        public string DiscountCode { get; set; }


    }
}
