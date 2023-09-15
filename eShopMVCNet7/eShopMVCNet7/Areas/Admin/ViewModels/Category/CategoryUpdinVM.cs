using System.ComponentModel.DataAnnotations;

namespace eShopMVCNet7.Areas.Admin.ViewModels.Category
{
	public class CategoryUpdinVM
	{
		public int Id { get; set; }
		[MaxLength(100)]
		[MinLength(5)]
		public string Name { get; set; }
		[MaxLength(100)]

		public string Slug { get; set; }
	}
}
