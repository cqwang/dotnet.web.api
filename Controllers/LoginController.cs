using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;



namespace dotnet.web.api
{
	public class LoginController : BaseController
	{
		private static List<User> _userList;
		internal static List<User> UserList
		{
			get
			{
				if (_userList == null)
				{
					_userList = new List<User>();
					_userList.Add(new User() { ID = 1, Name = "xiaoxiao", Password = "123" });
					_userList.Add(new User() { ID = 2, Name = "dada", Password = "456" });
				}
				return _userList;
			}
		}


		[HttpPost]
		public string Login([FromBody]User user)
		{
			if (UserList.Exists(p => p.Name == user.Name && p.Password == user.Password))
			{
				UserAuthentication.AddUserTicketToResponse(user);

				return user.Name + " Login Success";
			}
			else
			{
				return user.Name + " Invalid User";
			}
		}
	}
}
