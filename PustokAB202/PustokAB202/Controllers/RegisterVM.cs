﻿namespace PustokAB202.Controllers
{
	public class RegisterVM
	{
		public string Name { get; set; }

		public string Surname { get; set; }
		public string Username { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
		public string Gender { get; internal set; }
	}
}