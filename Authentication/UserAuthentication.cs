using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

using Invest.WebAPI.Models;

namespace dotnet.web.api
{
	public class UserAuthentication
	{
		private const string Key = "USER_LOGIN_TICKET";

		public static void AddUserTicketToResponse(User user)
		{
			var userData = new UserData()
			{
				UserName = user.Name,
				UserHostAddress = HttpContext.Current.Request.UserHostAddress
			};

			var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddYears(1), true, JsonConvert.SerializeObject(userData));
			var ticketMessage = FormsAuthentication.Encrypt(ticket);
			HttpContext.Current.Response.Headers.Add(Key, ticketMessage);
		}

		public static UserData GetUserDataFromRequest()
		{
			var ticketMessage = HttpContext.Current.Request.Headers[Key];
			if (ticketMessage == null || ticketMessage.Equals("null", StringComparison.CurrentCultureIgnoreCase))
			{
				return null;
			}

			var ticket = FormsAuthentication.Decrypt(ticketMessage);
			return JsonConvert.DeserializeObject<UserData>(ticket.UserData);
		}

		public static void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}