using eShopMVCNet7.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopMVCNet7.Controllers
{
	public class AccountController : Controller
	{
		[HttpGet] //có thể viết hoặc không vì nó đã được set default sẵn rồi. 
		public IActionResult Register() => View(); //lambda expression

		[HttpPost]

		public IActionResult Register(AppUser user, [FromServices] eShopDbContext db)
		{
			if (ModelState.IsValid == false)
			{
				return View();
			}

			//chuẩn hóa email và username
			user.Username = user.Username.ToUpper().Trim();
			user.Email = user.Email.ToUpper().Trim();

			//check xem username và email đã tồn tại chưa
			var exists = db.AppUser.Any(u => u.Email == user.Email || u.Username == user.Username);
			if (exists)
			{
				ModelState.AddModelError("", "Email hoặc tên đăng nhập đã tồn tại!");
				return View();
			}
			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

			user.Role = Common.UserRole.ROLECUSTOMER;
			user.BlockedTo = null;

			db.AppUser.Add(user);
			db.SaveChanges();

			return RedirectToAction(nameof(Register));
		}
	}
}

