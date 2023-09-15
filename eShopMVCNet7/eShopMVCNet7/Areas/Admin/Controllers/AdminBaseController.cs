using eShopMVCNet7.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopMVCNet7.Areas.Admin.Controllers
{
	public class AdminBaseController : Controller
	{
		protected const int PER_PAGE = 20;
		protected eShopDbContext _db;

		public AdminBaseController(eShopDbContext db)
		{
			_db = db; 
		}

		protected void SetSuccessMesg (string msg)
		{
			TempData["_Success"] = msg;
		}

		protected void SetErrorMesg(string msg)
		{
			TempData["_Errors"] = msg;
		}
	}
}
