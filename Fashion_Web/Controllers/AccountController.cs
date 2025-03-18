using Fashion_Web.Models;
using Fashion_Web.Services;
using Fashion_Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace Fashion_Web.Controllers
{
    [Route("acc")]
    public class AccountController : Controller
    {
        private readonly QLBanDoThoiTrangContext _context;

        public AccountController(QLBanDoThoiTrangContext context)
        {
            _context = context;
        }

        [Route("dang-nhap")]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.IsInRole("KhachHang") ?
                    RedirectToAction("Home", "Home") :
                    RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("dang-nhap")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            Console.WriteLine(login.Email);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "");
                return View(login);
            }
            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user != null)
            {
                
                var hashedPassword = SecurityService.HashPasswordWithSalt(login.Password, user.Salt);
                
                if (hashedPassword == user.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, login.Email),
                        new Claim(ClaimTypes.Role, user.LoaiUser)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuthentication");

                    // Thiết lập thuộc tính AuthenticationProperties
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe,
                        ExpiresUtc = login.RememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddMinutes(30)
                    };
                    await HttpContext.SignInAsync("MyCookieAuthentication", new ClaimsPrincipal(claimsIdentity), authProperties);
                    if (user.LoaiUser == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Home", "Home");
                }
            }
            
            ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không chính xác.");
            return View(login);
        }

        [Route("dang-xuat")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuthentication");
            return RedirectToAction("Login", "Account");
        }

        [Route("dang-ky")]
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.IsInRole("KhachHang") ?
                    RedirectToAction("Home", "Home") :
                    RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("dang-ky")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "");
                return View(register);
            }

            if (register.Password != register.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu không khớp.");
                return View("Register");
            }

            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Email == register.Email);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, "Email đã được sử dụng.");
                return View("Register");
            }
            
            var salt = SecurityService.GenerateSalt();
            var hashedPassword = SecurityService.HashPasswordWithSalt(register.Password, salt);

            bool isFirstUser = !_context.TUsers.Any();

            var newUser = new TUser
            {
                Email = register.Email,
                Password = hashedPassword,
                Salt = salt,
                LoaiUser = isFirstUser ? "Admin" : "KhachHang"
            };

            _context.TUsers.Add(newUser);
            _context.SaveChanges();
            if (newUser.LoaiUser == "KhachHang")
            {
                var newCustomer = new TKhachHang
                {
                    Email = register.Email,
                    TenKhachHang = register.Name,
                    NgaySinh = register.DateOfBirth,
                    SoDienThoai = register.PhoneNumber,
                    DiaChi = register.StreetAddress + "," + register.District + "," + register.Province,
                    GhiChu = null,
                    User = newUser
                };
                _context.TKhachHangs.Add(newCustomer);
                _context.SaveChanges();
                _context.SaveChanges();
            }
            
            TempData.Clear();
            TempData["Success"] = 1;
            return RedirectToAction("Login", "Account");
        }


        [Route("quen-mat-khau")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.IsInRole("KhachHang") ?
                    RedirectToAction("Home", "Home") :
                    RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("quen-mat-khau")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "");
                return View(forgot);
            }

            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Email == forgot.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email không tồn tại.");
                return View(forgot);
            }
            TempData["status"] = 0;
            TempData["MaKhachHang"] = JsonSerializer.Serialize(forgot);
            return RedirectToAction("VerifyEmail");
        }

        [Route("doi-mat-khau")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [Route("doi-mat-khau")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel change)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "");
                return View(change);
            }

            if (change.Password != change.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu mới không khớp.");
                return View(change);
            }
            var email = JsonSerializer.Deserialize<ForgotPasswordViewModel>(TempData["MaKhachHang"].ToString());
            TempData.Keep();

            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Email == email.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Người dùng không tồn tại.");
                return View(change);
            }
            var salt = SecurityService.GenerateSalt();
            var hashedNewPassword = SecurityService.HashPasswordWithSalt(change.Password, salt);
            user.Password = hashedNewPassword;
            user.Salt = salt;
            _context.SaveChanges();

            TempData["Success"] = 2;
            return RedirectToAction("Login", "Account");
        }
    }
}
