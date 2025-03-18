using Fashion_Web.Models;

namespace Fashion_Web.ViewModels
{
    public class HomeProductDetailViewModel
    {
        public TDanhMucSp product { get; set; }
        public List<TAnhSp> productImages { get; set; }
        public List<string> Sizes { get; set; }             
        public List<string> Colors { get; set; }
    }
}
