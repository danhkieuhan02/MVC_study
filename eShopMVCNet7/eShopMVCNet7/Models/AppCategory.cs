﻿using System.ComponentModel.DataAnnotations;

namespace eShopMVCNet7.Models
{
	public class AppCategory
	{
		public int Id {get; set;}
		public string Name {get; set;}
		public string Slug { get; set; }
	}
}
