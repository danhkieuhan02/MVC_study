using Microsoft.EntityFrameworkCore;
using eShopMVCNet7.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace eShopMVCNet7.Models
{
	[Index("Username", IsUnique = true)]
	[Index("Email", IsUnique = true)]

	public class AppUser
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Tên đăng nhập không được trống!")] //Not null
		[MaxLength(100, ErrorMessage = "xxx")]
		public string Username { get; set; }

		[MaxLength(200)]
		[Required(ErrorMessage = "Trường này không được trống!")]
		public string Password { get; set; }
		[NotMapped]
		[Compare("Password", ErrorMessage = "Mật khẩu không khớp!")]

		[Required(ErrorMessage = "Trường này không được trống!")]
		public string Cfmpassword { get; set; }
		public UserRole Role { get; set; } //Phân quyền cho admin và user.

		[MaxLength(20)]
		[Required(ErrorMessage = "Trường này không được trống!")]
		public string PhoneNumber { get; set; }

		[MaxLength(50)]

		[Required(ErrorMessage = "Trường này không được trống!")]
		public string Address { get; set; }

		[MaxLength(50)]
		[Required(ErrorMessage = "Trường này không được trống!")]
		public string Email { get; set; }
		public DateTime? BlockedTo { get; set; } //Dùng cho chức năng khóa tài khoản. 
	}
}
