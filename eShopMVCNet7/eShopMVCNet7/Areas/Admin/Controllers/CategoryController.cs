using eShopMVCNet7.Areas.Admin.ViewModels.Category;
using eShopMVCNet7.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eShopMVCNet7.Areas.Admin.Controllers
{
	public class CategoryController : AdminBaseController
	{
        public CategoryController(eShopDbContext db) : base (db) 
		{ 
		}
        public IActionResult Index() => View(); //khi load empty page thi data moi duoc push len.
		public IActionResult ListAll2()
		{
			var data = _db.AppCategories
						.OrderByDescending(x => x.Id) //thằng nào mới nhất mang lên đầu.
						.ToList();
			return Ok(data); //mã request 200 ->Ok: thành công. 
		}
		public List<CategoryListItemsVM> ListAll()
		{
			var data = _db.AppCategories
				.Select(x => new CategoryListItemsVM
				{
					Id = x.Id,
					Name = x.Name,
				})
				.OrderByDescending(x => x.Id)
				.ToList();
			return data;
		}
	}
}
