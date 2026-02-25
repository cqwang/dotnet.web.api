using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Invest.WebAPI.Authentication;

namespace dotnet.web.api
{
    public class LogoutController : BaseController
    {
		[HttpPost]
		public bool Logout()
		{
			var userData = UserAuthentication.GetUserDataFromRequest();
			if (userData != null)
			{
				UserAuthentication.SignOut();
				return true;
			}

			return false;
		}
    }
}
