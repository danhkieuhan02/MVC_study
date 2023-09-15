using eShopMVCNet7.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace eShopMVCNet7.Areas.Admin.Controllers
{
	public class UserController : AdminBaseController
	{
		public UserController(eShopDbContext db) : base(db)
		{ }

		public IActionResult Index(int page = 1)
		{
			var data = _db.AppUser.OrderByDescending(x => x.Id).ToPagedList(page, PER_PAGE);
			return View(data);
		}

		public IActionResult Update(int id)
		{
			var data = _db.AppUser.Find(id);   // id trong Find(id) là khóa chính, ctr tự tìm

			if (data == null)
			{
				SetErrorMesg("Your information was wrong!");
				return RedirectToAction(nameof(Index));
			}
			return View(data);
		}

		[HttpPost]
		public IActionResult Update(int id, AppUser user)
		{
			var oldUser = _db.AppUser.Find(id);
			if (oldUser == null)
			{
				return RedirectToAction(nameof(Index));
			}
			//validate date va update cho mot so thuoc tinh
			ModelState.Remove("Username");
			ModelState.Remove("Password");
			ModelState.Remove("Cfmpassword");
			//validate
			if (ModelState.IsValid == false)
			{
				return View(user);
			}

			//chuan hoa email
			user.Email = user.Email.ToLower().Trim();

			//Check xem email da ton tai chua
			var exists = _db.AppUser.Any(u => u.Email == user.Email && u.Id != id);
			if (exists)
			{
				ModelState.AddModelError("", "Email used");
				return View(user);
			}

			//upate data
			oldUser.Email = user.Email;
			oldUser.Address = user.Address;
			oldUser.Role = user.Role;
			oldUser.PhoneNumber = user.PhoneNumber;

			//save
			_db.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int id)
		{
			var data = _db.AppUser.Find(id);   // id trong Find(id) là khóa chính, ctr tự tìm

			if (data == null)
			{
				return RedirectToAction(nameof(Index));
			}
			_db.Remove(data);
			_db.SaveChanges();
			SetSuccessMesg($"Your account [{data.Username}] removed");
			return RedirectToAction(nameof(Index));

		}
	}
}
