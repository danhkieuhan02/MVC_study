﻿namespace eShopMVCNet7.Models
{
	public class AppOrder
	{
		public int Id { get; set; }
		public double TotalPrice { get; set; } //tổng giá 
		public string CustomerName { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerAddress { get; set; }
		public int? CustomerId { get; set; }
		public int? Status { get; set; } //Chờ tiếp nhận, đã tiếp nhận, đã giao hàng, bị hủy. 
		public DateTime? CreateAt { get; set; }
	}
}
