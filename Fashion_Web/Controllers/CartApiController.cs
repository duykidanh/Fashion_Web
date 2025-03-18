using Fashion_Web.Models;
using Fashion_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Web.Controllers
{
    [Route("api/gio-hang")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly QLBanDoThoiTrangContext _context;
        public CartApiController(QLBanDoThoiTrangContext context)
        {
            _context = context;
        }


        [HttpDelete("xoa")]
        public async Task<IActionResult> RemoveItemFromCart([FromBody] int cartId)
        {
            var cart = await _context.TGioHangs.FirstOrDefaultAsync(x => x.MaGioHang == cartId);
            if (cart == null)
            {
                return NotFound();
            }
            _context.TGioHangs.Remove(cart);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("cap-nhat")]
        public async Task<IActionResult> UpdateQuantityItem([FromBody] CartItemUpdateViewModel item)
        {
            var cart = await _context.TGioHangs.FirstOrDefaultAsync(x => x.MaGioHang == item.Id);
            if (cart == null)
            {
                return NotFound();
            }
            cart.SoLuong = item.Quantity;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
